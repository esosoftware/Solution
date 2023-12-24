namespace Esoft.Documents.Data.Model
{
    public class DocumentModel
    {
        /// <summary>
        /// List of all documents
        /// </summary>
        public ICollection<Document> Documents;

        /// <summary>
        /// Count of all lines
        /// </summary>
        public int LineCount { get; set; }

        /// <summary>
        /// Count of all chars
        /// </summary>
        public int CharCount { get; set; }
    }
}