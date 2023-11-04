using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var products = new List<Product>
            {
                new Product { ID = 1, Name = "Pizza", Price = 22, CreatedDate = "10.10.23" },
                new Product { ID = 2, Name = "Milk", Price = 5, CreatedDate = "10.11.23" },
                new Product { ID = 3, Name = "Butter", Price = 3, CreatedDate = "01.09.23" }
            };

            return View(products);
        }
    }
}
