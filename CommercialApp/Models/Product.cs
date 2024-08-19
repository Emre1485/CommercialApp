using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommercialApp.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(30)]
        public string Brand { get; set; }
        public short Stock { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public bool State { get; set; }
        [StringLength(256)]
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public ICollection<SaleTransaction> SaleTransactions { get; set; }

    }
}
