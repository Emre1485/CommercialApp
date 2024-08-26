using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommercialApp.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(30)]
        public string Surname { get; set; }
        [StringLength(256)]
        public string Title { get; set; } = "title";
        public string Email { get; set; } = "@gmail.com";
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        public ICollection<SaleTransaction> SaleTransactions { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }

    
}
