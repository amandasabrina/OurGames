using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OurGames.Common.Security;
using OurGames.Core.Entity;
using OurGames.Core.Model;
using OurGames.Repository;
using OurGames.UI.Models;

namespace OurGames.UI.Controllers
{
    public class UserController : AbstractController
    {
        private readonly CustomerRepository _userRepository;

        public UserController(DbContextOptions<OurGamesContext> contextOptions)
        {
            _userRepository = new CustomerRepository(contextOptions);
        }

        public IActionResult Index()
        {
            return View(_userRepository.GetAll().ConvertAll(u => UserViewModel.Map(u)));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                //TODO: Handle avatar image and save

                var (salt, hash) = HMACSHA512Helper.CreateHMACSHA12Hash(model.Password);

                var addresses = new List<Address>();

                if (model.Addresses.Any())
                {
                    foreach (var address in model.Addresses)
                    {
                        addresses.Add(new Address
                        {
                            Cep = address.CEP,
                            City = address.City,
                            Street = address.Street,
                            Number = address.Number,
                            Uf = address.UF
                        });
                    }
                }

                var entity = new Customer
                {
                    BirthDate = model.BirthDate,
                    Email = model.Email,
                    Address = addresses,
                    //Avatar = avatarUrl,
                    AccessLevelId = UserAccessLevel == AccessLevelType.Admin ? 1 : 2,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Phone = model.Phone,
                    PasswordSalt = salt,
                    PasswordHash = hash,
                    Cpf = model.CPF,
                    LoginMethodId = (int)LoginMethods.Email
                };
            }

            return View(model);
        }
    }
}