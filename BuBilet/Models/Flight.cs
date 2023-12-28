using Microsoft.AspNetCore.Cors;
using System.ComponentModel.DataAnnotations;

namespace BuBilet.Models
{
    public class Flight
    {
        [Key]
        public string FlightNumber { get; set; }


        [Display(Name ="Kalkış Havaalanı")]
        public string Source { get; set; }


        [Display(Name ="İnşi Havaalanı")]
        public string Destination { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }

        public  List<Seat> Seats { get; set; }
    }
}
