using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext db;

        public HomeController(ApplicationContext context)
        {
            db = context;
            InitializeDatabase();
        }
        private void InitializeDatabase()
        {
            if (!db.Users.Any())
            {
                db.Users.AddRange(
                    new User { FirstName = "Maryna", LastName = "Horshevska", Age = 19 },
                    new User { FirstName = "Ellina", LastName = "Palko", Age = 20 },
                    new User { FirstName = "Katya", LastName = "Gromova", Age = 20 }
                );

                db.SaveChanges();
            }
            //if (!db.Companies.Any())
            //{
            //    db.Companies.AddRange(
            //        new Company { Name = "GlobalLogic", Year = 2000 },
            //        new Company { Name = "Google", Year = 1998 },
            //        new Company { Name = "Apple", Year = 1976 },
            //        new Company { Name = "Microsoft", Year = 1975 },
            //        new Company { Name = "Samsung", Year = 1969 }
            //    );

            //    db.SaveChanges();
            //}
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Users.ToListAsync());
            //return View(await db.Companies.ToListAsync());
        }
    }

}