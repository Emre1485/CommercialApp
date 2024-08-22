using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommercialApp.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        [StringLength(6)]
        public string InvoiceNumber { get; set; }
        [StringLength(1)]
        public string InvoiceSeries { get; set; }
        public DateTime Date { get; set; }
        
        [Column(TypeName ="char")]
        [StringLength(5)]
        public string Time { get; set; }

        [StringLength(60)]
        public string TaxOffice { get; set; }
        [StringLength(30)]
        public string Sender { get; set; }
        [StringLength(30)]
        public string Receiver { get; set; }

        public decimal Amount { get; set; }
        public ICollection<InvoiceItem> InvoiceItems { get; set; }

    }
}
