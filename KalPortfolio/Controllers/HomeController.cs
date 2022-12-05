using Microsoft.AspNetCore.Mvc;

namespace KalPortfolio.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();  
        }

       public ActionResult Projects()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Resume()
        {
            return View();
        }
    }
}
