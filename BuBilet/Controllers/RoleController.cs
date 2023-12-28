using BuBilet.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace BuBilet.Controllers
{
    public class RoleController : Controller
    { 
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = $"{Constants.Roles.Administrator}")]
        public IActionResult Adminx()
        {
            return View();
        }

    }
}
