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


        public string  FlightId { get; set; }
        public  virtual Flight? Flight { get; set; }

        public string SeatNumber { get; set; }




    }
}