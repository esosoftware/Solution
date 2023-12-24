using System.Reflection.Metadata.Ecma335;

namespace Esoft.Documents.Data.Model
{
    public class DocumentHeader
    {
        /// <summary>
        /// Kod BA
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Typ dokumentu
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Numer dokumentu
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Data operacji
        /// </summary>
        public DateTime OperationDate { get; set; }

        /// <summary>
        /// Numer dnia doumentu
        /// </summary>
        public string NumberOfDocumentDay { get; set; }

        /// <summary>
        /// Kod kontrahenta
        /// </summary>
        public string CustomerCode { get; set; }

        /// <summary>
        /// Nazwa kontrahenta
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Numer dokumentu zewn.
        /// </summary>
        public string DocumentNumberExternal { get; set; }

        /// <summary>
        /// data dokumentu zewn.
        /// </summary>
        public DateTime DocumentDateExternal { get; set; }

        /// <summary>
        /// Netto
        /// </summary>
        public Decimal NetValue { get; set; }

        /// <summary>
        /// Vat
        /// </summary>
        public Decimal VatValue { get; set; }
        
        /// <summary>
        /// Brutto
        /// </summary>
        public Decimal GrossValue { get; set; }

        /// <summary>
        /// F1
        /// </summary>
        public string F1 { get; set; }
        
        /// <summary>
        /// F2
        /// </summary>
        public string F2 { get; set; }
        
        /// <summary>
        /// F3
        /// </summary>
        public string F3 { get; set; }

    }
}