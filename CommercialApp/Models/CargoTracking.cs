using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommercialApp.Models
{
    public class CargoTracking
    {
        [Key]
        public int CargoTrackingId { get; set; }
        [Column(TypeName ="VarChar(10)")]
        public string TrackingNumber { get; set; }
        [Column(TypeName = "VarChar(150)")]
        public string Description { get; set; }
        public DateTime Date { get; set; }

    }
}
