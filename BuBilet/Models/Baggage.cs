using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BuBilet.Models
{
    public class Baggage
    {
        [Key]
        public int BaggageID { get; set; }

        // CustomerID sütununu temsil eden özellik
        [ForeignKey("Customers")]
        public int CustomerID { get; set; }

        // Customers tablosu ile ilişkiyi temsil eden gezinti özelliği
        public virtual Customers Customers { get; set; }

        // BaggageStatusUpdates tablosu ile ilişkiyi temsil eden gezinti özelliği

    }
}
