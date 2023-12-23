using System.ComponentModel.DataAnnotations;

namespace BuBilet.Models
{
    public class FlightStatus
    {
        [Key]
        public int StatusID { get; set; }
        [StringLength(100)]
        public string StatusDescription { get; set; }

        // Navigation property
        public virtual ICollection<FlightStatusUpdates> FlightStatusUpdates { get; set; }

    }
}
