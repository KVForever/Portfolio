using DataEntities;
using MessagesLibrary;
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

        public ActionResult Index()
        {
            return View(_repository.GetAllMessages());
        }

        [HttpPost]
        public ActionResult Search(Guid search)
        {
            return View(_repository.GetMessageById(search));
        }
    }
}
