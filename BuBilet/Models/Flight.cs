﻿using Microsoft.AspNetCore.Cors;
using System.ComponentModel.DataAnnotations;

namespace BuBilet.Models
{
    public class Flight
    {
        [Key]
        public string FlightId{ get; set; }


        [Display(Name ="Kalkış Havaalanı")]
        public string Source { get; set; }


        [Display(Name ="İniş Havaalanı")]
        public string Destination { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }


        public List<Seat> Seats { get; set; }



    }
}
