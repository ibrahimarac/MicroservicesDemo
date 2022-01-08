
using Assesment.Core.Models;
using Microsoft.Extensions.Hosting;
using OfficeOpenXml;
using Report.Application.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Report.Infrastructure.Services
{
    public class ExcelFileBuilder : IExcelFileBuilder
    {
        private readonly IHostEnvironment _environment;

        public ExcelFileBuilder(IHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string> CreateExcelFileAsync(Guid raporId, RaporTalep rapor)
        {
            return await Task.Run(() =>
            {
                //Excel dosya oluşturma işlemi için EPPlus nuget paketi kullanılmıştır.
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

                    var filePath = Path.Combine(_environment.ContentRootPath, "files", $"{raporId}.xlsx");

                    FileInfo excelFile = new FileInfo(filePath);
                    excel.SaveAs(excelFile);
                    return filePath;
                }
            });
        }
    }

}
