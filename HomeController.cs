using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;
using WebApplication4.Filters;

namespace WebApplication4.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpGet("/")]
        [LogActionFilter]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("/uniq")]
        [UniqueUsersFilter]
        public IActionResult Uniq()
        {
            return View();
        }
    }
}
