using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace BuBilet.Models
{
    public class Seat
    {
        [Key]
        public string SeatNumber { get; set; }
       
        public bool IsAvailable { get; set; }


        
      

       
       
    }
}
