using DataEntities;
using KalPortfolio.Models;
using LoginLibrary;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using KalPortfolio.Helpers;
using System.Linq;
using Microsoft.IdentityModel.Tokens;

namespace KalPortfolio.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepository _repository;
        private readonly IRoleRepository _roleRepository;
        public LoginController(ILoginRepository repository, IRoleRepository roleRepository)
        {
            _repository = repository;
            _roleRepository = roleRepository; 
        }

        public ActionResult Login(string returnUrl = "/")
        {
            if (HttpContext.User != null && HttpContext.User.Identity != null && HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("Home", "Home");

            UserLoginModel model = new();
            {
                model.ReturnUrl = returnUrl;
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Login(UserLoginModel login)
        {
            if (ModelState.IsValid)
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
                }
                ModelState.AddModelError("", "Login Failed. Please try again");
            }            
            return View(login);
        }
       

        public async Task<ActionResult> CreateAccount()
        {
            CreateAccount model = new()
            {
                Roles = await _roleRepository.GetAllRoles()
            };

            return View(model);
        }

        

        [HttpPost]
        public async Task<ActionResult> CreateAccount(CreateAccount model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _repository.GetUserByUsername(model.Username);

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
                                    Name = "User",                                    
                                }).ToList();


                        }

                        await _repository.CreateAccount(user);
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
