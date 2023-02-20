using MessagesLibrary;
using Microsoft.AspNetCore.Mvc;

namespace KalPortfolio.Controllers
{
    public class Login : Controller
    {
        public readonly IMessageRepository _repository;

        public Login(IMessageRepository message)
        {
            _repository = message;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login login)
        {

        }
    }
}
