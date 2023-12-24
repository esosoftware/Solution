using System.Reflection.Metadata.Ecma335;

namespace Esoft.Documents.Data.Model
{
    public class DocumentItem
    {
        /// <summary>
        /// Kod produktu
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Nazwa produktu
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ilość
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// Cena netto
        /// </summary>
        public decimal NetPrice { get; set; }


        /// <summary>
        /// Wartosc netto
        /// </summary>
        public decimal NetValue { get; set; }

        /// <summary>
        /// Wartosc VAT
        /// </summary>
        public decimal VatValue { get; set; }

        /// <summary>
        /// Ilosc przed
        /// </summary>
        public decimal QuantityBefore { get; set; }

        /// <summary>
        /// Srednia przed
        /// </summary>
        public decimal AverageBefore { get; set; }

        /// <summary>
        /// Ilosc przed
        /// </summary>
        public decimal QuantityAfter { get; set; }

        /// <summary>
        /// Srednia przed
        /// </summary>
        public decimal AverageAfter { get; set; }

        /// <summary>
        /// Grupa
        /// </summary>
        public string Group { get; set; }

    }
}