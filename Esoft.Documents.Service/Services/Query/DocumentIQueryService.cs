using Esoft.Documents.Data.Model;
using Esoft.Documents.Dto;
using Esoft.Documents.Service.Interface.Services.FileStorages;
using Esoft.Documents.Service.Interface.Services.Query;
using Esoft.Documents.Service.Interface.Services.Validator;
using Esoft.Documents.Service.Services.Validator;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esoft.Documents.Service.Services.Query
{
    public class DocumentQueryService : IDocumentQueryService
    {
        readonly IDocumentValidatorService _documentvalidatorService;
        readonly IFileStorageService _filestorageService;

        public DocumentQueryService(
            IDocumentValidatorService documentValidatorService,
            IFileStorageService fileStorageService)
        {
            _documentvalidatorService = documentValidatorService;
            _filestorageService = fileStorageService;
        }

        public Task<DocumentResponse> GetDocumentStatistics(IFormFile file, int x)
        {
            var fileAsText = _filestorageService.ReadFileAsync(file).Result;
            var documentModel = _documentvalidatorService.AssertDocumentValid(fileAsText);

            var maxNetValue = documentModel.Documents
                .SelectMany(document => document.Items)
                .Max(x => x.NetValue);

            var maxNetValueNames = documentModel.Documents
                .SelectMany(document => document.Items.Where(x => x.NetValue == maxNetValue))
                .Select(x => x.Name).ToList();

            DocumentResponse result = new DocumentResponse
            {
                Documents = documentModel.Documents.ToList(),
                LineCount = documentModel.LineCount,
                CharCount = documentModel.CharCount,
                Sum = documentModel.Documents.Sum(x => x.Items.Sum(y => y.Quantity)),
                XCount = documentModel.Documents.Where(i => i.Items.Count > x).Count(),
                ProductsWithMaxNetValue = string.Join(",", maxNetValueNames)
        };
            
            return Task.FromResult(result);
        }
    }
}
