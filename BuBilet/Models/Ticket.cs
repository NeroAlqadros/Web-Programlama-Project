using BuBilet.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuBilet.Models
{
    public class Ticket
    {
        [Key]
        public string TicketNumber { get; set; }

        public string Id { get; set; }
        [ForeignKey("Id")]
        public ApplicationUser ApplicationUser { get; set; }

        public string FlightId { get; set; }

        [ForeignKey("FlightId")]
        public Flight Flight { get; set; }

        
    }
}