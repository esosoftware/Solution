using Esoft.Documents.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esoft.Documents.Service.Interface.Services.Validator
{
    public interface IDocumentValidatorService
    {
        /// <summary>
        /// Asserts that string is valid list of Documents and return DocumentModel (list of Documents with file statistics).
        /// </summary>
        /// <param name="documents"></param>
        /// <returns></returns>
        DocumentModel AssertDocumentValid(string documents);
    }
}
