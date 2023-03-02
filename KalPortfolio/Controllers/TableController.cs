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

       
        public ActionResult Index(string name)
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

        
        public ActionResult Delete(string id)
        {
            if(Guid.TryParse(id, out var result))
            {
                _repository.DeleteMessage(result);
            }

            return Redirect("/Table/Index");
        }

       
        public ActionResult Details(string id)
        {
            if(id != null)
            {
                if (Guid.TryParse(id, out var result))
                {                   
                    return View(_repository.GetMessageById(result));
                }
                return NotFound();
            }
            return NotFound();

            
        }

    }
}
