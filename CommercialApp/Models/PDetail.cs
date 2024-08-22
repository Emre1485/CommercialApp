using System.ComponentModel.DataAnnotations;

namespace CommercialApp.Models
{
    public class PDetail
    {
        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        public string ProductName  { get; set; }
        [StringLength(2000)]
        public string ProductInfo { get; set; }
    }
}
