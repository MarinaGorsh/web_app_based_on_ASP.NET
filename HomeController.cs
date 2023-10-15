using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Pizza(UserModel user)
        {
            return View(user);
        }
        public IActionResult SaveUser(ProductModel model)
        {
            return View(model);
        }
    }
}
