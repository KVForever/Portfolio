using DataEntities;
using MessagesLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using NuGet.Protocol.Core.Types;
using System;
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

        public ActionResult Index()
        {
            return View(_repository.GetAllMessages());
        }

       
        public ActionResult Index(string name)
        {
            if(_repository.GetAllMessages().Count == 0)
            {
                return Problem("There are no messages to search");
            }

            var message = from x in _repository.GetAllMessages()
                          select x;

            message = message.Where(y => y.FirstName.Contains(name));

            return View(message.ToList());
        }
    }
}
