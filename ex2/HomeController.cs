using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
