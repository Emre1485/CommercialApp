using System.ComponentModel.DataAnnotations;

namespace CommercialApp.Models
{
    public class InvoiceItem
    {
        [Key]
        public int Id { get; set; }
        [StringLength(150)]
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public Invoice Invoice { get; set; }
    }
}
