using BuBilet.Areas.Identity.Data;
using BuBilet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BuBilet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightApiController : ControllerBase
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: FlightApiController
        [HttpGet]
        public List<Flight> Get()
        {
            var flights = db.Flight.ToList();
            // normalde json formatına cevirip gondermem lazım  [ApiController] bunu otomatik yapıyor
            return flights;
        }

        // GET: FlightApiController/Details/5
        [HttpGet("{id}")]
        public ActionResult<Flight> Get(string? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            var flight = db.Flight.FirstOrDefault(z => z.FlightId == id);
            if (flight == null)
            {
                return NotFound();
            }
            return flight;
        }

        // GET: FlightApiController/Create
        [HttpPost]
        public IActionResult Post([FromBody] Flight f)
        {
            //if (ModelState.IsValid)  [ApiController] doğrulamayı yapoıypr
            db.Flight.Add(f);
            db.SaveChanges();
            return Ok(f);
        }
        // POST: FlightApiController/Create
        [HttpPut("{id}")]
        public  IActionResult Create(string? id, [FromBody] Flight f)
        {
            if (id is null)
            {
                return NotFound();
            }
            var flight = db.Flight.FirstOrDefault(z => z.FlightId == id);
            if (flight == null)
            {
                return NotFound();
            }
            flight.FlightId = f.FlightId;
            flight.Source = f.Source;
            flight.Destination = f.Destination;
            flight.DepartureDateTime = f.DepartureDateTime;
            flight.ArrivalDateTime = f.ArrivalDateTime;

            db.Update(flight);
            db.SaveChanges();
            return Ok(flight);
        }

        // GET: FlightApiController/Edit/5
      
        // POST: FlightApiController/Edit/5
        [HttpDelete("{id}")]
        public  IActionResult Delete(string? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            var flight = db.Flight.FirstOrDefault(z => z.FlightId == id);
            if (flight == null)
            {
                return NotFound();
            }

            var seats =  db.Seat.Where(s => s.FlightId == id).ToList();


            foreach (var seat in seats)
            {
                db.Seat.Remove(seat);
            }

            db.Flight.Remove(flight);
            db.SaveChanges();
            return Ok(flight);
        }
    }
}
