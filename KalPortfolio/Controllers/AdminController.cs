﻿using DataEntities;
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
    public class AdminController : Controller
    {
        private readonly IHomeRepository messageRepository;
        private readonly ILoginRepository loginRepository;
        private readonly IAdminRepository adminRepository;

        public AdminController(IHomeRepository messageRepository, ILoginRepository loginRepository, IAdminRepository adminRepository)
        {
            this.messageRepository = messageRepository;
            this.loginRepository = loginRepository;
            this.adminRepository = adminRepository;
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Home(string name)
        {
            if (HttpContext.User != null && HttpContext.User.Identity != null && HttpContext.User.Identity.IsAuthenticated)
            {
                return View(await messageRepository.GetMessagesByName(name));
            }
            return RedirectToAction("Login", "login");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult UserView()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<PartialViewResult> SearchResultList(string name)
        {
            return PartialView(await messageRepository.GetMessagesByName(name));
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteResultList(int id)
        {

            await messageRepository.DeleteMessage(id);
            return PartialView(await messageRepository.GetAllMessages());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Details()
        {                
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> MessageDetail(int id)
        {

            return PartialView(await messageRepository.GetMessageById(id));
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> ViewAdmins()
        {
            return View(await adminRepository.GetAdmins());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateAdmin()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteAdminResultList(int id)
        {
            await adminRepository.DeleteAdmin(id);
            return PartialView(await adminRepository.GetAdmins());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAdmin(CreateAccount model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await loginRepository.GetUserByUsername(model.Username);

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

                        await loginRepository.CreateAccount(user);
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
