using System.ComponentModel.DataAnnotations;

namespace BuBilet.Models
{
    public class PlaneTypes
    {
        [Key]
        public string  PlaneId { get; set; }

        public string PlaneType { get; set; }
    }
}
