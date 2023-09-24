using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalcController : Controller
    {
        private readonly CalcService calcService;

        public CalcController(CalcService calcService)
        {
            this.calcService = calcService;
        }

        public ActionResult Add(int A, int B)
        {
            int result = calcService.Sum(A, B);
            return View(result);
        }
        public ActionResult Min(int A, int B)
        {
            int result = calcService.Minus(A, B);
            return View(result);
        }
        public ActionResult Div(int A, int B)
        {
            int result = calcService.Divide(A, B);
            return View(result);
        }
        public ActionResult Mul(int A, int B)
        {
            int result = calcService.Multiple(A, B);
            return View(result);
        }
    }
}
