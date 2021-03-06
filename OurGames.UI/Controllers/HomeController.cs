﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OurGames.Common.Logging;
using OurGames.Core.Model;

namespace OurGames.UI.Controllers
{
    public class HomeController : AbstractController
    {
        public HomeController(DbContextOptions<OurGamesContext> contextOptions)
        {
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}