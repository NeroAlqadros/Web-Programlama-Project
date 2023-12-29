using BuBilet.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace BuBilet.Models
{
    public class Seat
    {
        [Key]
        public string FlightId { get; set; }

        [ForeignKey("FlightId")]
        public Flight Flight { get; set; }
        public string SeatNumber { get; set; }

        public bool IsAvailable { get; set; }

       
    }
}
