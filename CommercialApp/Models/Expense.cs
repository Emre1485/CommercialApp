using System.ComponentModel.DataAnnotations;

namespace CommercialApp.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
