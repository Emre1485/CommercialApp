using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommercialApp.Models
{
    public class Cargo
    {
        [Key]
        public int CargoId { get; set; }
        [Column(TypeName = "VarChar(400)")]
        public string Description { get; set; }
        [Column(TypeName = "VarChar(10)")]
        public string TrackingNumber { get; set; }
        [Column(TypeName = "VarChar(30)")]
        public string Employee { get; set; }
        [Column(TypeName = "VarChar(30)")]
        public string Receiver { get; set; }
        public DateTime Date { get; set; }
    }
}
