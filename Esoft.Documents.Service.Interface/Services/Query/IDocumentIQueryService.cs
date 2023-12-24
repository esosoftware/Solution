using Esoft.Documents.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esoft.Documents.Data.Model;
using Microsoft.AspNetCore.Http;

namespace Esoft.Documents.Service.Interface.Services.Query
{
    public interface IDocumentQueryService
    {
        /// <summary>
        /// Returns documents with statistics
        /// </summary>
        /// <param name="file"></param>
        /// <param name="x">X number parameter</param>
        /// <returns></returns>
        Task<DocumentResponse> GetDocumentStatistics(IFormFile file, int x);
    }
}