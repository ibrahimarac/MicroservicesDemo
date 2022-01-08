using Core.Application.Models;
using Karatekin.Web.Api.Core.Utilities.Result;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OfficeOpenXml;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Report.Application.CommandQueries.RaporIslemleri.Commands.CreateRapor;
using Report.Application.CommandQueries.RaporIslemleri.Commands.UpdateRapor;
using Report.Application.Interfaces.Common;
using Report.Messaging.Send.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Report.Messaging.Send.Receiver
{
    public class ReportRequestReceiver : BackgroundService
    {
        private IModel _channel;
        private IConnection _connection;
        IServiceScopeFactory _serviceFactory;
        private readonly IExcelFileBuilder _excelBuilder;
        private readonly string _hostname;
        private readonly string _queueName;
        private readonly string _username;
        private readonly string _password;

        public ReportRequestReceiver( 
            IOptions<RabbitMqConfiguration> rabbitMqOptions,
            IServiceScopeFactory serviceFactory,
            IExcelFileBuilder excelBuilder
        )
        {
            _serviceFactory = serviceFactory;
            _excelBuilder = excelBuilder;
            _hostname = rabbitMqOptions.Value.Hostname;
            _queueName = rabbitMqOptions.Value.QueueName;
            _username = rabbitMqOptions.Value.UserName;
            _password = rabbitMqOptions.Value.Password;
            InitializeRabbitMqListener();
        }

        private void InitializeRabbitMqListener()
        {
            var factory = new ConnectionFactory
            {
                HostName = _hostname,
                UserName = _username,
                Password = _password
            };

            _connection = factory.CreateConnection();
            _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received +=  async(ch, ea) =>
            {
                //konum bilgisini alalım
                var konum = Encoding.UTF8.GetString(ea.Body.ToArray());

                await HandleMessageAsync(konum);

                _channel.BasicAck(ea.DeliveryTag, false);
            };
            consumer.Shutdown += OnConsumerShutdown;
            consumer.Registered += OnConsumerRegistered;
            consumer.Unregistered += OnConsumerUnregistered;
            consumer.ConsumerCancelled += OnConsumerConsumerCancelled;

            _channel.BasicConsume(_queueName, false, consumer);

            await Task.CompletedTask;
        }

        private async Task HandleMessageAsync(string konum)
        {
            var scope = _serviceFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            //Öncelikle raporu veritabanında rapor tablosuna kaydedelim.
            var addRaporToDbResponse= await mediator.Send(new CreateRaporCommand());
            //rapor başarıyla veritabanına kaydedilmişse
            if(addRaporToDbResponse.Success)
            {
                //rapora verilen id değerini öğrenelim.
                //bu değeri rapor durumunu değiştirmek için kullanacağız.
                var raporId = (addRaporToDbResponse as SuccessDataResponse<Guid>).Data;

                var raporBilgileriResponse = await CollectReportInfoAsync(konum);

                //Olayı simule etmek amacıyla gecikme verelim.
                await Task.Delay(10000);

                //rapor bilgileri başarıyla alındı.
                if (raporBilgileriResponse != null)
                {
                    //Excel dosyasına verileri yaz.
                    string path=await _excelBuilder.CreateExcelFileAsync(raporId,raporBilgileriResponse);

                    await UpdateReportStatus(raporId, path);
                }
            }
        }


        private async Task<Response> UpdateReportStatus(Guid raporId,string path)
        {
            var scope = _serviceFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            //sonrasında ilgili raporun durumunu güncelle.
            return await mediator.Send(new UpdateRaporCommand
                            {
                                Id = raporId,
                                Rapor = new Application.Dtos.RaporUpdateDto
                                {
                                    DurumId = new Guid("2143a48a-7190-4ee0-a894-743733ac09b9"),
                                    Path = path
                                }
                            });
        }



        private async Task<RaporTalep> CollectReportInfoAsync(string konum)
        {
            //Bu konum bilgisine ait raporun talep edildiği bilgisi Contact api'ye gönderilerek
            //rapora ait datalar alınıyor.

            var client = new RestClient($"http://localhost:60000/api/rapor/get-by-konum/{konum}");
            var request = new RestRequest();
            request.Timeout = -1;
            request.Method = Method.Get;
            var response = await client.ExecuteAsync(request);
            var responseResult = JsonConvert.DeserializeObject<DataResponse<RaporTalep>>(response.Content);

            if (responseResult.Success)
            {
                //Buradan donem veri RaporTalep türündendir.
                var raporTalepResponse = JsonConvert.DeserializeObject<DataResponse<RaporTalep>>(response.Content);
                //Rapor içeriği RaporTalep türünden geldi.
                var raporBilgileri = raporTalepResponse.Data;
                return raporBilgileri;
            }
            return null;
        }



        private async Task<string> CreateExcelFileAsync(Guid raporId,RaporTalep rapor)
        {
            return await Task.Run(() =>
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage excel = new ExcelPackage())
                {
                    excel.Workbook.Worksheets.Add("Worksheet1");
                    excel.Workbook.Worksheets.Add("Worksheet2");
                    excel.Workbook.Worksheets.Add("Worksheet3");

                    var headerRow = new List<string[]>()
                      {
                        new string[] { "Konum", "Kişi Sayısı", "Telno Sayısı" },
                        new string[]{rapor.Konum,rapor.KisiSayisi.ToString(),rapor.TelnoSayisi.ToString()}
                      };

                    // Değerlerin yazılacağı hücre aralığı
                    string headerRange = "A1:C1";

                    // Hedef çalışma sayfası
                    var worksheet = excel.Workbook.Worksheets["Worksheet1"];

                    // Verileri ilgili hücrelere yansıt.
                    worksheet.Cells[headerRange].LoadFromArrays(headerRow);

                    var filePath = Path.Combine(_environment.ContentRootPath,"files", $"{raporId}.xlsx");

                    FileInfo excelFile = new FileInfo(filePath);
                    excel.SaveAs(excelFile);
                    return filePath;
                }
            });
            
        }



        private void OnConsumerConsumerCancelled(object sender, ConsumerEventArgs e)
        {
        }

        private void OnConsumerUnregistered(object sender, ConsumerEventArgs e)
        {
        }

        private void OnConsumerRegistered(object sender, ConsumerEventArgs e)
        {
        }

        private void OnConsumerShutdown(object sender, ShutdownEventArgs e)
        {
        }

        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
    }
}