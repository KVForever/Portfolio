using DataEntities;
using MessagesLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace KalPortfolio.Controllers
{
    public class TableController : Controller
    {
        private readonly IMessageRepository _repository;

        public TableController(IMessageRepository message)
        {
            _repository = message;
        }

       
        public IActionResult Index(string name)
        {
            if(name != null)
            {
                if(_repository.GetMessageByName(name).Count > 0)
                {
                    return View(_repository.GetMessageByName(name));
                }
                
            }
            if(name != null && _repository.GetMessageByName(name).Count == 0 )
            {

                return NotFound();
            }
            
            return View(_repository.GetAllMessages());
        }

        
        public IActionResult Delete(int id)
        {
            UserMessage message = _repository.GetMessageById(id);

            if(message != null)
            {
                _repository.DeleteMessage(id);
            }
            
            return Redirect("/Table/Index");
        }

       
        public IActionResult Details(int id)
        {
            UserMessage message = _repository.GetMessageById(id);

            if(message != null)
            {
                return View(_repository.GetMessageById(id));
            }
                            
            return NotFound();
        }

    }
}
