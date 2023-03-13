using DataEntities;
using MessagesLibrary;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalPortfolio.Controllers
{
    
    public class HomeController : Controller
    {
       
        private readonly IMessageRepository _repository;

        public HomeController(IMessageRepository message)
        {
            _repository = message;
        }
       
        public IActionResult Home()
        {    
            return View();  
        }

        [HttpPost]
        
        public IActionResult Home(UserMessage formData)
        {        
            if(ModelState.IsValid)
            {
                _repository.AddMessage(formData);
            }
            return View(formData);
        }

        [HttpPost]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("/Login/Login");
        }

    }
}
