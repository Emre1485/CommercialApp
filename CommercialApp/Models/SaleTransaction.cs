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
        public int ProductsId { get; set; }
        public virtual Product Products { get; set; }
        public int CustomerAccountsId { get; set; }
        public virtual CustomerAccount CustomerAccounts { get; set; }
        public int EmployeesId { get; set; }
        public virtual Employee Employees { get; set; }
    }
}
