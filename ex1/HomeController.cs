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
            List<Product> products = new List<Product>
            {
                new Product { ID = 1, Name = "Pizza", Price = 22 },
                new Product { ID = 2, Name = "Milk", Price = 5 },
                new Product { ID = 3, Name = "Butter", Price = 3 }
            };

            return View(products);
        }
    }
}
