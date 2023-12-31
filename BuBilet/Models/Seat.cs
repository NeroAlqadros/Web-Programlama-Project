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
        public string FlightNumber { get; set; }

     
        

        public string SeatNumber { get; set; }

        public bool IsAvailable { get; set; }

        public Flight Flight { get; set; }

    }
}
