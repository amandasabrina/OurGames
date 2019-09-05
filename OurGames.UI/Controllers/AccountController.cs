using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OurGames.UI.Models;

namespace OurGames.UI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var claims = new List<Claim>
                    {
                        //new Claim(ClaimTypes.Name, model)
                    };
                }
                catch (Exception ex)
                {

                    throw;
                }
            }

            return View();
        }

        public IActionResult Logout()
        {
            return View();
        }
    }
}