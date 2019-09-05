using Microsoft.EntityFrameworkCore;
using OurGames.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OurGames.Repository
{
    public class AddressRepository : AbstractRepository<Endereco>
    {
        public AddressRepository(DbContextOptions<OurGamesContext> contextOptions) : base(contextOptions)
        {
        }

        public override IEnumerable<Endereco> GetAll()
        {
            return db.Endereco.ToList();
        }

        public override Endereco GetById(int id)
        {
            return db.Endereco.FirstOrDefault(e => e.EnderecoId == id);
        }
    }
}
