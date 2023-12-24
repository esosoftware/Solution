namespace Esoft.Documents.Data.Model
{
    public class Document
    {
        /// <summary>
        /// Nagłówek dokumentu
        /// </summary>
        public DocumentHeader Header { get; set; }

        /// <summary>
        /// Pozycje dokumentu
        /// </summary>
        public ICollection<DocumentItem> Items { get; set; }

        /// <summary>
        /// Komentarze
        /// </summary>
        public ICollection<string> Comments { get; set; }
    }
}