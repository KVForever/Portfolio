using DataEntities;
using KalPortfolio.Helpers;
using KalPortfolio.Models;
using LoginLibrary;
using MessagesLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
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
        public ActionResult UserView()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Home(string name)
        {
            if(name != null)
            {    
                var message = await _repository.GetMessagesByName(name);

                if(message.Any())
                {
                    return View(message);
                }
                return View("Error");
            }

            return View(await _repository.GetAllMessages());
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id) 
        {
            /* Is it better to have var or UserMessage*/

            var message = await _repository.GetMessageById(id);

            if(message != null)
            {
                await _repository.DeleteMessage(id);
                return Redirect("/Admin/Home");
            }

            return NotFound();
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Details(int id)
        {
            var message = await _repository.GetMessageById(id);

            if(message != null)
            {
                return View( await _repository.GetMessageById(id));
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
                        return RedirectToAction("Home", "Home");
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
