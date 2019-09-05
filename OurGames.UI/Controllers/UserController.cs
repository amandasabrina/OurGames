using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OurGames.Core.Model;
using OurGames.Repository;

namespace OurGames.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly UserRepository _userRepository;

        public UserController(DbContextOptions<OurGamesContext> contextOptions)
        {
            _userRepository = new UserRepository(contextOptions);
        }

        public IActionResult Index()
        {
            return View(_userRepository.GetAll());
        }
    }
}