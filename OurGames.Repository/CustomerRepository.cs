using Microsoft.EntityFrameworkCore;
using OurGames.Common.Security;
using OurGames.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace OurGames.Repository
{
    public class CustomerRepository : AbstractRepository<Customer>
    {
        public CustomerRepository(DbContextOptions<OurGamesContext> contextOptions) : base(contextOptions)
        {
        }

        public override List<Customer> GetAll()
        {
            return db.Customer
                .Include(u => u.CustomerId)
                .Include(u => u.AccessLevel)
                .ToList();
        }

        public override Customer GetById(int id)
        {
            return db.Customer
                .Include(u => u.AccessLevel)
                .Include(u => u.Address)
                .FirstOrDefault(u => u.CustomerId == id);
        }

        public Customer GetByLogin(string login)
        {
            return db.Customer
                .Include(u => u.AccessLevel)
                .FirstOrDefault(u => u.Email == login);
        }

        public Customer Authenticate(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login))
                throw new ArgumentNullException(nameof(login));

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException(nameof(password));

            var user = GetByLogin(login);

            if (user is null)
                return null;

            if (HMACSHA512Helper.IsAValidHash(password, user.PasswordSalt, user.PasswordHash))
            {
                return user;
            }

            return null;
        }

       
    }
}
