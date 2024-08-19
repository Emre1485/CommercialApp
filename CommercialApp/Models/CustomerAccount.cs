using System.ComponentModel.DataAnnotations;

namespace CommercialApp.Models
{
    public class CustomerAccount
    {
        [Key]
        public int Id { get; set; }
        [StringLength(30,ErrorMessage = "En fazla 30 karakter girebilirsiniz!")]
        public string Name { get; set; }
        [StringLength(30, ErrorMessage = "En fazla 30 karakter girebilirsiniz!")]
        public string Surname { get; set; }
        [StringLength(20, ErrorMessage = "En fazla 20 karakter girebilirsiniz!")]
        public string City { get; set; }
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz!")]
        public string Email { get; set; }
        public bool State { get; set; } = true;
        public ICollection<SaleTransaction> SaleTransactions { get; set; }
    }
}
