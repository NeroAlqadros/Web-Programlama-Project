using BuBilet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BuBilet.Controllers
{
    
    public class CallFlightApiController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Flight> flights = new List<Flight>();
            HttpClient client = new HttpClient();
            // var response = await client.GetAsync("https://www.haberturk.com/");
            var response = await client.GetAsync("https://localhost:7289/api/FlightApi");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            flights = JsonConvert.DeserializeObject<List<Flight>>(jsonResponse);


            return View(flights);
        }


    }
}
