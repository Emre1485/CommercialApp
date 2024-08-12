using System.ComponentModel.DataAnnotations;

namespace CommercialApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
