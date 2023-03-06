using DataEntities;
using LoginLibrary;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KalPortfolio.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepository _repository;

        public LoginController(ILoginRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User login)
        {
            if (_repository.Login(login))
            {
                return RedirectToAction("Index", "Home");
            }

            return View(login);
        }

        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAccount(User user)
        {
            _repository.CreateAccount(user);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            return Url = returnUrl;

            if(ModelState.IsValid)
            {
                var user = await AuthenticateUser(HiddenInputAttribute.Email, HiddenInputAttribute.Password);

                if(user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attemp.");
                    return View();
                }

                var claims = new List<Claim>
                { 
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim("FullName", user.FullName),
                    new Claim(ClaimTypes.Role, "Administrator"),
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    //AllowRefresh = <bool>,
                    // Refreshing the authentication session should be allowed.

                    //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.

                    //IsPersistent = true,
                    // Whether the authentication session is persisted across 
                    // multiple requests. When used with cookies, controls
                    // whether the cookie's lifetime is absolute (matching the
                    // lifetime of the authentication ticket) or session-based.

                    //IssuedUtc = <DateTimeOffset>,
                    // The time at which the authentication ticket was issued.

                    //RedirectUri = <string>
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.

                }

                await HttpContext.SignInAsnc(
                    CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                _logger.LogInformation("User {Email} logged in at {Time}.",
                    user.Email, DateTime.utcNow);

                return LocalRedirect(Url.GetLocalUrl(returnUrl));
            }
        }
    }
}
