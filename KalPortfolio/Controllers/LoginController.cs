
using DataEntities;
using LoginLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace KalPortfolio.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepository _repository;

        public LoginController(ILoginRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        
        public ActionResult Index(Users login)
        {
            
                if (login != null)
                {
                    if (_repository.Login(login))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                return View();
            
            
        }
        public ActionResult CreateAccount()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult CreateAccount(Users createAccount)
        {
            
             return View(CreateAccount(createAccount));
            
            
        }

        
    }
}
