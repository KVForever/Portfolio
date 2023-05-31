using DataEntities;
using MessagesLibrary;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using KalPortfolio.Models;
using Microsoft.AspNetCore.Http;

namespace KalPortfolio.Controllers
{
    
    public class HomeController : Controller
    {
       
        private readonly IHomeRepository _homeRepository;

        public HomeController(IHomeRepository homeRepostiory)
        {
            _homeRepository = homeRepostiory;
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
        public async Task Home(CreateMessage formData)
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
                await _homeRepository.AddMessage(userMessage);
            }
           
        }



        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task SiteRating(AddRating stars)
        {
            StarRating userRating = new();
            {
                userRating.Rating = stars.Rating;
            }

            await _homeRepository.AddRating(userRating);

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
