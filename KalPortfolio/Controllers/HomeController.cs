using DataEntities;
using MessagesLibrary;
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

        public ActionResult Index()
        {
            UserMessages dto = new UserMessages();
            return View(dto);  
        }

        [HttpPost]
        public ActionResult Index( UserMessages formData)
        {        
            if(ModelState.IsValid)
            {
                _repository.AddMessage(formData);
            }
            return View(formData);
        }
    }
}
