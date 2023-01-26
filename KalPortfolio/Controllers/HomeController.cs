using DataEntities;
using DataLogic;
using Microsoft.AspNetCore.Mvc;

namespace KalPortfolio.Controllers
{
    public class HomeController : Controller
    {
        MessageLogic message = new MessageLogic();

        public ActionResult Index()
        {
            return View();  
        }

        [HttpPost]
        public ActionResult Index(Message formData)
        {
            if(ModelState.IsValid)
            {
                Message user = message.NewMessage(formData);
            }
            return View();
        }

    }
}
