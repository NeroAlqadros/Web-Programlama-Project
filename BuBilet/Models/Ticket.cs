using BuBilet.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuBilet.Models
{
    
    public class Ticket
    {
        [Key]
        public string TicketId { get; set; }

        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }

      

        [ForeignKey("Flight")]
        public string FlightId { get; set; }

        [ForeignKey("Seat")]
        public string SeatId { get; set; }



    }
}