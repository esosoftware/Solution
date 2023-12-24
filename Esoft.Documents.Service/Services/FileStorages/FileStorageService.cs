using Esoft.Documents.Service.Interface;
using Esoft.Documents.Service.Interface.Services.FileStorages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Esoft.Documents.Service.Services.FileStorages
{
    public class FileStorageService : IFileStorageService
    {
        private readonly ILogger<FileStorageService> _logger;

        public FileStorageService(ILogger<FileStorageService> logger)
        {
            _logger = logger;
        }

        public async Task<string> ReadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                _logger.LogInformation("File not exists");
                throw new FileNotFoundException("File not exists");
            }

            using (var streamReader = new StreamReader(file.OpenReadStream()))
            {
                _logger.LogInformation("File has been read.");
                return await streamReader.ReadToEndAsync();
            }
        }
    }
}