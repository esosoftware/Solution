using Esoft.Documents.Data.Model;

namespace Esoft.Documents.Dto
{
    public class DocumentResponse
    {
        /// <summary>
        /// Documents list
        /// </summary>
        public IEnumerable<Document> Documents { get; set; }

        /// <summary>
        /// Count of all lines
        /// </summary>
        public int LineCount { get; set; }

        /// <summary>
        /// Count of all chars
        /// </summary>
        public int CharCount { get; set; }

        /// <summary>
        /// Sum of items
        /// </summary>
        public Decimal Sum { get; set; }

        /// <summary>
        /// Count documents with more than x items
        /// </summary>
        public int XCount { get; set; }

        /// <summary>
        /// Products names with the most price
        /// </summary>
        public string ProductsWithMaxNetValue { get; set; }


    }
}