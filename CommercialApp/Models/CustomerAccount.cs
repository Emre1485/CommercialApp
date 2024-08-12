using System.ComponentModel.DataAnnotations;

namespace CommercialApp.Models
{
    public class CustomerAccount
    {
        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(30)]
        public string Surname { get; set; }
        [StringLength(20)]
        public string City { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        public ICollection<SaleTransaction> SaleTransactions { get; set; }
    }
}
