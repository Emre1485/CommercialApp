using System.ComponentModel.DataAnnotations;

namespace CommercialApp.Models
{
    public class SaleTransaction
    {
        [Key]
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; } 
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
        public Product Products { get; set; }
        public CustomerAccount CustomerAccounts { get; set; }
        public Employee Employees { get; set; }
    }
}
