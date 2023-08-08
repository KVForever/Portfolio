using DataEntities;
using KalPortfolio.Helpers;
using KalPortfolio.Models;
using KalPortfolio.Repositories.Interfaces;
using LoginLibrary;
using MessagesLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace KalPortfolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IHomeRepository _messageRepository;
        private readonly ILoginRepository _loginRepository;
        private readonly IAdminRepository _adminRepository;

        public AdminController(IHomeRepository messageRepository, ILoginRepository loginRepository, IAdminRepository adminRepository)
        {
            _messageRepository = messageRepository;
            _loginRepository = loginRepository;
            _adminRepository = adminRepository;
        }


        public async Task<ActionResult> Home(string name)
        {
            if (HttpContext.User != null && HttpContext.User.Identity != null && HttpContext.User.Identity.IsAuthenticated)
            {
                return View(await _messageRepository.GetMessagesByName(name));
        }
            return RedirectToAction("Login", "login");
    }


        public ActionResult UserView()
        {
            return View();
        }

 
        public async Task<PartialViewResult> SearchResultList(string name)
        {
            return PartialView(await _messageRepository.GetMessagesByName(name));
        }

   
        public async Task<ActionResult> DeleteResultList(int id)
        {

            await _messageRepository.DeleteMessage(id);
            return PartialView(await _messageRepository.GetAllMessages());
        }

    
        public ActionResult Details()
        {                
            return View();
        }

  
        public async Task<ActionResult> MessageDetail(int id)
        {

            return PartialView(await _messageRepository.GetMessageById(id));
        }


        public async Task<ActionResult> ViewAdmins()
        {
            return View(await _adminRepository.GetAdmins());
        }

 
        public ActionResult CreateAdmin()
        {
            return View();
        }


        public async Task<ActionResult> DeleteAdminResultList(int id)
        {
            await _adminRepository.DeleteAdmin(id);
            return PartialView(await _adminRepository.GetAdmins());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAdmin(CreateAccount model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _loginRepository.GetUserByUsername(model.Username);

                if (existingUser == null)
                {
                    if (model.Password == model.ConfirmPassword)
                    {
                        var salt = UserHelper.GetSalt();

                        User user = new();
                        {
                            user.Email = model.Email;
                            user.FirstName = model.FirstName;
                            user.LastName = model.LastName;
                            user.Username = model.Username;
                            user.Password = UserHelper.GetHashedPassword(model.Password, salt);
                            user.Salt = salt;
                            
                            user.Roles = model.SelectedRoles.Select(r =>
                                new Role()
                                {
                                    Id = r,
                                    Name = "Admin",
                                }).ToList();
                        }

                        await _loginRepository.CreateAccount(user);
                        return RedirectToAction("Home", "Admin");
                    }
                    ModelState.AddModelError("Password", "Passwords do not match");
                }
                ModelState.AddModelError("Username", "Username is invalid.");
            }
            
            return View(model);
        }

    }
}
