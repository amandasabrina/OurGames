using Microsoft.EntityFrameworkCore;
using OurGames.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace OurGames.Repository
{
    public class UserRepository : AbstractRepository<Usuario>
    {
        public UserRepository(DbContextOptions<OurGamesContext> contextOptions) : base(contextOptions)
        {
        }

        public override List<Usuario> GetAll()
        {
            return db.Usuario
                .Include(u => u.Endereco)
                .Include(u => u.NivelAcesso)
                .ToList();
        }

        public override Usuario GetById(int id)
        {
            return db.Usuario
                .Include(u => u.NivelAcesso)
                .Include(u => u.Endereco)
                .FirstOrDefault(u => u.UsuarioId == id);
        }

        public Usuario GetByLogin(string login)
        {
            return db.Usuario
                .Include(u => u.NivelAcesso)
                .FirstOrDefault(u => u.Email == login);
        }

        public Usuario Authenticate(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login))
                throw new ArgumentException(nameof(login));

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException(nameof(password));

            var user = GetByLogin(login);

            if (user is null)
                return null;

            //if (ValidateCredentials(user))
            //{

            //}

            return null;
        }

        public (byte[] passwordHash, byte[] salt) CreateCredentials(string password)
        {
            using (var hmac = new HMACSHA512())
            {
                var salt = hmac.Key;

                var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                return (salt, passwordHash);
            }
        }
    }
}
