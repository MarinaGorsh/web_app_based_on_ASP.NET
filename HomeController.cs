using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string Index(User user)
        {
            if (user.Date.DayOfWeek == DayOfWeek.Saturday || user.Date.DayOfWeek == DayOfWeek.Sunday)
            {
                ModelState.AddModelError("Date", "Бажана дата консультації не може бути в суботу або неділю.");
            }
            if (user.Date.Hour >= 19 || user.Date.Hour <= 6)
            {
                ModelState.AddModelError("Date", "Бажана дата консультації не може бути в неробочі часи");
            }
            if (user.Date.DayOfWeek == DayOfWeek.Monday && user.Product == "Основи")
            {
                ModelState.AddModelError("Product", "Консультація з основ не проводиться у понеділки");
            }
            if (ModelState.IsValid)
            {
                return $"Ви були успішно зареєстровані.\nВаша дата консультації - {user.Date}\nВи обрали {user.Product}";
            }
            string errorMessages = "";
            foreach(var item in ModelState)
            {
                if (item.Value.ValidationState == ModelValidationState.Invalid)
                {
                    errorMessages = $"{errorMessages}\nПомилка властивості {item.Key}:\n";
                    foreach (var error in item.Value.Errors)
                    {
                        errorMessages = $"{errorMessages}{error.ErrorMessage}\n";
                    }
                }
            }
            return errorMessages;
        }
    }
}
