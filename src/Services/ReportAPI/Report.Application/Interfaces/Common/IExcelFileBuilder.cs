
using Core.Application.Models;
using System;
using System.Threading.Tasks;

namespace Report.Application.Interfaces.Common
{
    public interface IExcelFileBuilder
    {
        Task<string> CreateExcelFileAsync(Guid raporId, RaporTalep rapor);
    }
}
