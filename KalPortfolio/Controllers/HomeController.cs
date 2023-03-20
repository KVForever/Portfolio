using DataEntities;
using MessagesLibrary;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using KalPortfolio.Models;

namespace KalPortfolio.Controllers
{
    
    public class HomeController : Controller
    {
       
        private readonly IMessageRepository _repository;

        public HomeController(IMessageRepository message)
        {
            _repository = message;
        }
       
        public ActionResult Home()
        {    
            return View();  
        }

        [HttpPost]
        public async Task<ActionResult> Home(CreateMessage formData)
        {        
            if(ModelState.IsValid)
            {
                UserMessage userMessage = new();
                {
                    userMessage.FirstName = formData.FirstName;
                    userMessage.LastName = formData.LastName;
                    userMessage.Email = formData.Email;
                    userMessage.Subject = formData.Subject;
                    userMessage.Message = formData.Message;
            
                }

                await _repository.AddMessage(userMessage);
            }
            return View(formData);
        }

        [HttpPost]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");
           
        }

    }
}
