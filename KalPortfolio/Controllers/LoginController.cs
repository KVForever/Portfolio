using KalPortfolio.Models;
using LoginLibrary;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using KalPortfolio.Helpers;


namespace KalPortfolio.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepository _repository;
        

        public LoginController(ILoginRepository repository)
        {
            _repository = repository;
             
        }

        public ActionResult Login()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
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

                            login.ReturnUrl = "/Admin/Home";                           
                        }

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity)); 

                        return LocalRedirect(login.ReturnUrl);
                    }
                    ModelState.AddModelError("Password", "Your password is incorrect");
                }
                ModelState.AddModelError("Username", "Your username is invalid");
               
            }            
            return View(login);
        }
    }
}
