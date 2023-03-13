using DataEntities;
using KalPortfolio.Helpers;
using KalPortfolio.Models;
using LoginLibrary;
using MessagesLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace KalPortfolio.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMessageRepository _repository;
        private readonly ILoginRepository _loginRepository;
        private readonly IRoleRepository _roleRepository;
        public AdminController(IMessageRepository message, ILoginRepository login, IRoleRepository role)
        {
            _repository = message;
            _loginRepository = login;
            _roleRepository = role;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Tables(string name)
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

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            UserMessage message = _repository.GetMessageById(id);

            if(message != null)
            {
                _repository.DeleteMessage(id);
            }
            
            return Redirect("/Table/Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Details(int id)
        {
            UserMessage message = _repository.GetMessageById(id);

            if(message != null)
            {
                return View(_repository.GetMessageById(id));
            }
                            
            return NotFound();
        }

        [Authorize(Roles = "Admin")]
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
                            user.Token = UserHelper.GenerateToken();
                            user.Roles = model.SelectedRoles.Select(r =>
                                new Role()
                                {
                                    Id = r,
                                    Name = "User",
                                }).ToList();
                        }

                        await _loginRepository.CreateAccount(user);
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("Password", "Passwords Do Not Match");
                }
                ModelState.AddModelError("Username", "Username Already in Use");
            }
            model.Roles = await _roleRepository.GetAllRoles();
            return View(model);
        }

    }
}
