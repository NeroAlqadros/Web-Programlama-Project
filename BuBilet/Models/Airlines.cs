using System.ComponentModel.DataAnnotations;

namespace BuBilet.Models
{
    public class Airlines
    {
        [Required]
        [Key]
        public int AirlineID { get; set; }
        [Required]
        [StringLength(50)]
        public string AirlineName { get; set; }
    }
}
