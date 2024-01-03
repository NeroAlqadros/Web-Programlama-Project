using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuBilet.Models
{
    public class Flight
    {
        [Key]
        public string FlightId{ get; set; }


       
        public string Source { get; set; }


        
        public string Destination { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }



        [ForeignKey("PlaneTypes")]
        public  string PlaneId { get; set; }

    }
}
