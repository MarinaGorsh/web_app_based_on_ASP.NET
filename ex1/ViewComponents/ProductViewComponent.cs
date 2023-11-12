using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication4.Models;

namespace WebApplication4.ViewComponents
{
    [ViewComponent(Name = "Product")]
    public class ProductViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<Product> products)
        {
            return View(products);
        }
    }
}

