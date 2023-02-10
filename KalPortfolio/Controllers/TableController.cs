using DataEntities;
using KalPortfolio.Models;
using MessagesLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace KalPortfolio.Controllers
{
    public class TableController : Controller
    {
        private readonly IMessageRepository _repository;

        public TableController(IMessageRepository message)
        {
            _repository = message;
        }

        public ActionResult Index(string? name)
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
            if (Guid.TryParse(id, out var result))
            {
                return View(_repository.GetMessageById(result));
            }

            return NotFound();
        }

    }
}
