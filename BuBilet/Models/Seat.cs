using BuBilet.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;


namespace BuBilet.Models
{
    
    public class Seat
    {
        [Key]
        public string SeatId { get; set; }

        [ForeignKey("Flight")]
        public string FlightId { get; set; }

     
        

        public string SeatNumber { get; set; }

        public bool IsAvailable { get; set; }

        public virtual Flight Flight { get; set; }

    }
}
