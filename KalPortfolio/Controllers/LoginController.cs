using DataEntities;
using LoginLibrary;
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
        public IActionResult Index(User login)
        {
            if (_repository.Login(login))
            {
                return RedirectToAction("Index", "Home");
            }

            return View(login);
        }

        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAccount(User user)
        {
            _repository.CreateAccount(user);

            return RedirectToAction("Index", "Home");
        }
    }
}
