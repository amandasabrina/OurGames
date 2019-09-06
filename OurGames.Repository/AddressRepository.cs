using Microsoft.EntityFrameworkCore;
using OurGames.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OurGames.Repository
{
    public class AddressRepository : AbstractRepository<Address>
    {
        public AddressRepository(DbContextOptions<OurGamesContext> contextOptions) : base(contextOptions)
        {
        }

        public override List<Address> GetAll()
        {
            return db.Address.ToList();
        }

        public override Address GetById(int id)
        {
            return db.Address.FirstOrDefault(e => e.AddressId == id);
        }
    }
}
