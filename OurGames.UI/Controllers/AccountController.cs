using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OurGames.Core.Model;
using OurGames.Repository;
using OurGames.UI.Models;

namespace OurGames.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly CustomerRepository _customerRepository;

        public AccountController(DbContextOptions<OurGamesContext> dbContextOptions)
        {
            _customerRepository = new CustomerRepository(dbContextOptions);
        }

        [Route("Account/SignIn/{provider}")]
        public IActionResult SignInExternalAuth(string provider, string returnUrl)
        {
            var authenticationProperties = new AuthenticationProperties
            {
                RedirectUri = returnUrl ?? Url.Action("Index", "Home"),                
            };

            return Challenge(authenticationProperties, provider);
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _customerRepository.Authenticate(model.Email, model.Password);

                if (user == null)
                {
                    //ViewData["messageError"] = _localizer["InvalidCredentials"].Value;

                    return View(model);
                }

                if (!user.Active)
                {
                    //ViewData["messageError"] = _localizer["DisabledUser"].Value;

                    return View(model);
                }

                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1),
                    RedirectUri = Url.Action("Index", "Home")
                };

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(user.FirstName)),
                    //new Claim(ClaimTypes.Name, model.Email.Split('@').First()),
                    new Claim(ClaimTypes.Email, model.Email),
                    new Claim(ClaimTypes.Role,  user.AccessLevel.Description), //user.Cargo.Nome
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties).Wait();

                if (!string.IsNullOrWhiteSpace(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        public IActionResult Logout()
        {
            return View();
        }
    }
}