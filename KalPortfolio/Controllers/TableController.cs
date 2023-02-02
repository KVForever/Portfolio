using MessagesLibrary;
using Microsoft.AspNetCore.Mvc;

namespace KalPortfolio.Controllers
{
    public class TableController : Controller
    {
        private readonly IMessageRepository _repository;

        public TableController(IMessageRepository message)
        {
            _repository = message;
        }

        public IActionResult Index()
        {
            return View(_repository.GetAllMessages());
        }
    }
}
