﻿using DataEntities;
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


        public AdminController(IMessageRepository message, ILoginRepository login)
        {
            _repository = message;
            _loginRepository = login;

        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Home(string name)
        {
            if (HttpContext.User != null && HttpContext.User.Identity != null && HttpContext.User.Identity.IsAuthenticated)
            {
                return View(await _repository.GetMessagesByName(name));
            }
            return RedirectToAction("Login", "login");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult UserView()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<PartialViewResult> UserResultList(string name)
        {
            return PartialView(await _repository.GetMessagesByName(name));
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteResultList(int id)
        {

            await _repository.DeleteMessage(id);
            return PartialView(await _repository.GetAllMessages());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Details()
        {                
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UserDetailList(int id)
        {

            return PartialView(await _repository.GetMessageById(id));
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateAdmin()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
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
                    ModelState.AddModelError("Password", "Passwords Do Not Match");
                }
                ModelState.AddModelError("Username", "Username Already in Use");
            }
            
            return View(model);
        }

    }
}
