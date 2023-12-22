using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BuBilet.Models
{
    public class Flights
    {
        [Key]
        public int FlightID { get; set; }
        [ForeignKey(nameof(Airlines))]
        public int AirlineID { get; set; }
        [ForeignKey(nameof(Airlines))]
        public int DepartureAirportID { get; set; }
        [ForeignKey(nameof(Airlines))]
        public int ArrivalAirportID { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        // Navigation properties
        public virtual Airlines Airline { get; set; }
        public virtual Airports DepartureAirport { get; set; }
        public virtual Airports ArrivalAirport { get; set; }
        public virtual ICollection<Tickets> Tickets { get; set; }
        public virtual ICollection<FlightStatusUpdates> FlightStatusUpdates { get; set; }
        public virtual ICollection<Seats> Seats { get; set; }
    }
}
