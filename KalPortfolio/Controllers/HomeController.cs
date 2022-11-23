using Microsoft.AspNetCore.Mvc;

namespace KalPortfolio.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Message = "This is what you should see when you start application";
            return View();  
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}
