using Microsoft.AspNetCore.Mvc;

namespace SalesWebMVC2022.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
