using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommercialApp.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        [StringLength(15)]
        public string UserName { get; set; }
        [StringLength(30)]
        public string Password { get; set; }
        [StringLength(15)]
        public string Permission { get; set; }
    }
}
