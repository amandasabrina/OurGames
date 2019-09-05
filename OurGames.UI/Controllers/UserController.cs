using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OurGames.Core;
using OurGames.Core.Model;
using OurGames.Repository;
using OurGames.UI.Models;

namespace OurGames.UI.Controllers
{
    public class UserController : AbstractController
    {
        private readonly UserRepository _userRepository;

        public UserController(DbContextOptions<OurGamesContext> contextOptions)
        {
            _userRepository = new UserRepository(contextOptions);
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

                var addresses = new List<Endereco>();

                if (model.Addresses.Any())
                {
                    foreach (var address in model.Addresses)
                    {
                        addresses.Add(new Endereco
                        {
                            Cep = address.CEP,
                            Cidade = address.City,
                            Logradouro = address.Street,
                            Numero = address.Number,
                            Uf = address.UF
                        });
                    }
                }

                var entity = new Usuario
                {
                    DataNascimento = model.BirthDate,
                    Email = model.Email,
                    Endereco = addresses,
                    //Avatar = avatarUrl,
                    NivelAcessoId = UserAccessLevel == AccessLevel.Admin ? 1 : 2,
                    Nome = model.FirstName,
                    Sobrenome = model.LastName,
                    Telefone = model.Phone
                };
            }

            return View(model);
        }
    }
}