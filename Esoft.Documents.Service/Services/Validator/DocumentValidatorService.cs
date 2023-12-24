using Esoft.Documents.Data.Model;
using Esoft.Documents.Service.Interface.Services.Validator;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Esoft.Documents.Common;
using Esoft.Documents.Common.Exceptions;

namespace Esoft.Documents.Service.Services.Validator
{
    public class DocumentValidatorService : IDocumentValidatorService
    {
        public DocumentModel AssertDocumentValid(string documents)
        {
            string message;
            if (!AssertNotEmptyDocuments(documents, out message))
                throw new NotFoundException(message);

            if (!AssertDocumentColumnsNumber(documents))
                throw new NotFoundException($"Document is not valid");
            
            var listOfDocuments = new List<Document>();
            Document currentDocument = new Document();
            List<string> listOfLines = documents.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var returnDocumentModel = new DocumentModel
            {
                CharCount = documents.Length,
                LineCount = listOfLines.Count(),
                Documents = listOfDocuments
            };
            
            foreach(string line in listOfLines)
            {
                var splittedLine = line.Split(',');

                if (splittedLine[0] == "H")
                {
                    currentDocument = new Document
                    {
                        Items = new List<DocumentItem>(),
                        Comments = new List<string>()
                    };
                        
                    currentDocument.Header = MappStringToDocumentHeader(splittedLine);
                    listOfDocuments.Add(currentDocument);
                }

                if (splittedLine[0] == "B")
                {
                    currentDocument.Items.Add(MappStringToDocumentItem(splittedLine));
                }

                if (splittedLine[0] == "C")
                {
                    currentDocument.Comments.Add(line);
                }

            }

            return returnDocumentModel;
        }

        private bool AssertDocumentColumnsNumber(string documents)
        {
            string allowedTypes = "HBC";
            List<string> listOfLines = documents.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string line in listOfLines)
            {
                var splittedLine = line.Split(',', StringSplitOptions.RemoveEmptyEntries);

                if (!allowedTypes.Contains(splittedLine[0]))
                    return false;

                switch (splittedLine[0])
                {
                    case "H":
                        {
                            if (splittedLine.Length != 16)
                                return false;
                            break;
                        }
                    case "B":
                        {
                            if (splittedLine.Length != 12)
                                return false;                            
                            break;
                        }
                }                
            }
            return true;
        }

        private bool AssertNotEmptyDocuments(string documents, out string message)
        {
            string allowedTypes = "HBC";
            List<string> listOfLines = documents.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            
            if(listOfLines.Count > 0)
            {
                var firstLine = listOfLines.First().Split(',', StringSplitOptions.RemoveEmptyEntries);
                if (firstLine.Length > 0 && firstLine[0] == "C")
                {
                    message = listOfLines.First();
                    return false;
                }
            }
            else
            {
                message = "Empty File";
                return false;
            }
            message = string.Empty;
            return true;
        }

        private DocumentHeader MappStringToDocumentHeader(string[] line)
        {
            CultureInfo culture = CultureInfo.InvariantCulture;

            return new DocumentHeader
            {
                Code = line[1],
                Type = line[2],
                Number = line[3],
                OperationDate = DateTime.Parse(line[4]),
                NumberOfDocumentDay = line[5],
                CustomerCode = line[6],
                CustomerName = line[7],
                DocumentNumberExternal = line[8],
                DocumentDateExternal = DateTime.Parse(line[9]),
                NetValue = ParseDecimal(line[10], culture),
                VatValue = ParseDecimal(line[11], culture),
                GrossValue = ParseDecimal(line[12], culture),
                F1 = line[13],
                F2 = line[14],
                F3 = line[15]
            };
        }

        private DocumentItem MappStringToDocumentItem(string[] line)
        {
            CultureInfo culture = CultureInfo.InvariantCulture;

            return new DocumentItem
            {
                Code = line[1],
                Name = line[2],
                Quantity = ParseDecimal( line[3], culture),
                NetPrice = ParseDecimal(line[4], culture),
                NetValue = ParseDecimal(line[5], culture),
                VatValue = ParseDecimal(line[6], culture),
                QuantityBefore = ParseDecimal(line[7], culture),
                AverageBefore = ParseDecimal(line[8], culture),
                QuantityAfter = ParseDecimal(line[9], culture),
                AverageAfter = ParseDecimal(line[10], culture),
                Group = line[11]
            };
        }

        private decimal ParseDecimal(string value, CultureInfo culture)
        {
            if (decimal.TryParse(value, NumberStyles.Number, culture, out decimal result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException($"Cannot convert value '{value}' to decimal.");
            }
        }

    }
}
