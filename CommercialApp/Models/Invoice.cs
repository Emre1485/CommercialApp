using System.ComponentModel.DataAnnotations;

namespace CommercialApp.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        public string InvoiceNumber { get; set; }
        [StringLength(16)]
        public string InvoiceSeries { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        [StringLength(60)]
        public string TaxOffice { get; set; }
        [StringLength(30)]
        public string Sender { get; set; }
        [StringLength(30)]
        public string Receiver { get; set; }
        public ICollection<InvoiceItem> InvoiceItems { get; set; }

    }
}
