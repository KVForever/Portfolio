using Microsoft.AspNetCore.Mvc;

namespace KalPortfolio.Pages
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
