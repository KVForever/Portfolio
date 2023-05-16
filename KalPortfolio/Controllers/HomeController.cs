using DataEntities;
using MessagesLibrary;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using KalPortfolio.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace KalPortfolio.Controllers
{
    
    public class HomeController : Controller
    {
       
        private readonly IHomeRepository homeRepository;

        public HomeController(IHomeRepository homeRepostiory)
        {
            this.homeRepository = homeRepostiory;
        }
       
        public ActionResult Home()
        {   
            if (HttpContext.User != null && HttpContext.User.Identity != null && HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Home", "Admin");
            }
            return View();  
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Home(CreateMessage formData)
        {
            if (ModelState.IsValid)
            {
                UserMessage userMessage = new();
                {
                    userMessage.FirstName = formData.FirstName;
                    userMessage.LastName = formData.LastName;
                    userMessage.Email = formData.Email;
                    userMessage.Subject = formData.Subject;
                    userMessage.Message = formData.Message;
            
                }
                await homeRepository.AddMessage(userMessage);
            }

           
            if (HttpContext.User != null && HttpContext.User.Identity != null && HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/Admin/UserView#contact-link");
                
            }

            return Redirect("/Home/Home#contact-link");
        }
        
        

        //[ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> SiteRating(AddRating stars)
        {
            StarRating userRating = new();
            {
                userRating.Rating = stars.Rating;
            }

            if(await homeRepository.AddRating(userRating))
            {
                return RedirectToAction("Home", "Home");
            }

            return View();
            
            
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");
           
        }

    }
}
