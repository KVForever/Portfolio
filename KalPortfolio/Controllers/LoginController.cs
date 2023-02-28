
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

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]       
        public ActionResult Index(User login)
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

        
        [HttpPost]
        public ActionResult CreateAccount(User createAccount)
        {

            _repository.CreateAccount(createAccount);

            return RedirectToAction("Index", "Home");
        }

        
    }
}
