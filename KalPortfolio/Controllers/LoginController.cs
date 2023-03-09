﻿using DataEntities;
using KalPortfolio.Models;

using LoginLibrary;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;
using KalPortfolio.Helpers;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KalPortfolio.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepository _repository;
       

        public LoginController(ILoginRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index(string returnUrl = "/")
        {
            if (HttpContext.User != null && HttpContext.User.Identity != null && HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            UserLoginModel model = new();
            {
                model.ReturnUrl = returnUrl;
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Index(UserLoginModel login)
        {
            var user = await _repository.GetUserByUsername(login.Username);
            if (user != null)
            {
                var hashedPassword = UserHelper.GetHashedPassword(login.Password, user.Salt);
                if (hashedPassword == user.Password)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim("FirstName", user.FirstName),
                        new Claim("LastName", user.LastName),
                        new Claim(ClaimTypes.Email, user.Email),
                    };

                    foreach (var role in user.Roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.Name));
                    }

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return LocalRedirect(login.ReturnUrl);
                }

                ModelState.AddModelError("", "Login Failed. Please try again");   
            }
            return View(login);
        }
        public ActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateAccount(CreateAccount model)
        {
            var existingUser = await _repository.GetUserByUsername(model.Username);

            if(existingUser == null)
            {
                if(model.Password == model.ConfirmPassword)
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
                        
                    }

                    await _repository.CreateAccount(user);
                    return RedirectToAction("Index","Home");
                }
                ModelState.AddModelError("Password", "Passwords Do Not Match");
            }
            ModelState.AddModelError("Username", "Username Already in Use");
            return View(model);
        }
    }
}
