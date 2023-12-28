using BuBilet.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuBilet.Models
{
    public class Ticket
    {
        
        public string BookingReference { get; set; }
        public DateTime BookingDateTime { get; set; }

        [ForeignKey(nameof(Seat))]
        public Seat Seat { get; set; }


        [ForeignKey(nameof(ApplicationUser))]
        public ApplicationUser Id { get; set; }
    }
}
