using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace WebApplication5.Models
{
    public class Airports
    {

        [Key]
        public int AirportID { get; set; }


        [StringLength(100)]
        public string AirportName { get; set; }
        [StringLength(50)]

        public string City { get; set; }
        [StringLength(50)]

        public string Country { get; set; }
    }
}
