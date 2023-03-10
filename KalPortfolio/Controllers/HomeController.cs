using DataEntities;
using MessagesLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace KalPortfolio.Controllers
{
    
    public class HomeController : Controller
    {
       
        private readonly IMessageRepository _repository;

        public HomeController(IMessageRepository message)
        {
            _repository = message;
        }
        [Authorize(Roles = "User")]
        public IActionResult Index()
        {    
            return View();  
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public IActionResult Index(UserMessage formData)
        {        
            if(ModelState.IsValid)
            {
                _repository.AddMessage(formData);
            }
            return View(formData);
        }

       
    }
}
