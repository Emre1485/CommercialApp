using System.ComponentModel.DataAnnotations;

namespace CommercialApp.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
