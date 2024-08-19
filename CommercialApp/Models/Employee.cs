using System.ComponentModel.DataAnnotations;

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
        public string Image { get; set; }
        public ICollection<SaleTransaction> SaleTransactions { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }

    
}
