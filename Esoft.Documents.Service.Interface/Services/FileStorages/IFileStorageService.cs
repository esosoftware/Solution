using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esoft.Documents.Service.Interface.Services.FileStorages
{
    public interface IFileStorageService
    {
        /// <summary>
        /// Read text file from the path
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        Task<string> ReadFileAsync(IFormFile filePath);
    }
}
