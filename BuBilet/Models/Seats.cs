using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BuBilet.Models
{
    public class Seats
    {
        [Key]
        public int SeatID { get; set; }

        // FlightID sütununu temsil eden özellik
        [ForeignKey("Flights")]
        public int FlightID { get; set; }

        // SeatNumber sütununu temsil eden özellik
        [Required]
        [StringLength(10)]
        public string SeatNumber { get; set; }

        // Flights tablosu ile ilişkiyi temsil eden gezinti özelliği
        public virtual Flights Flights { get; set; }

        // SeatReservations tablosu ile ilişkiyi temsil eden gezinti özelliği
        public virtual ICollection<SeatReservations> SeatReservations { get; set; }
    }
}
