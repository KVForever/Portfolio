using DataEntities;
using KalPortfolio.Models;
using MessagesLibrary;
using Microsoft.AspNetCore.Mvc;
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

        public ActionResult Index(string? name = null)
        {
            if(name != null)
            {
                if(_repository.GetMessageByName(name) != null)
                {
                    return View(_repository.GetMessageByName(name));
                }
                return NotFound();
                 
            }
            return View(_repository.GetAllMessages());
        }

       

        
    }
}
