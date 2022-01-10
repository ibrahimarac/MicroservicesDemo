using Assesment.Core.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Report.Messaging.Send.Options;
using System;
using System.Text;

namespace Report.Messaging.Send.Sender
{
    public class ReportRequestSender : IReportRequestSender
    {
        private readonly string _hostname;
        private readonly string _queueName;
        private readonly string _username;
        private readonly string _password;

        public ReportRequestSender(IOptions<RabbitMqConfiguration> rabbitMqOptions)
        {
            _hostname = rabbitMqOptions.Value.Hostname;
            _queueName = rabbitMqOptions.Value.QueueName;
            _username = rabbitMqOptions.Value.UserName;
            _password = rabbitMqOptions.Value.Password;
        }

        public bool SendReportRequest(RaporInfo rapor)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = _hostname, UserName = _username, Password = _password };

                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                    var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(rapor));

                    channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);
                }

                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
}
