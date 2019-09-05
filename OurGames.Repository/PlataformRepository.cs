using Microsoft.EntityFrameworkCore;
using OurGames.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OurGames.Repository
{
    public class PlataformRepository : AbstractRepository<Plataforma>
    {
        public PlataformRepository(DbContextOptions<OurGamesContext> contextOptions) : base(contextOptions)
        {
        }

        public override List<Plataforma> GetAll()
        {
            return db.Plataforma.ToList();
        }

        public override Plataforma GetById(int id)
        {
            return db.Plataforma.FirstOrDefault(p => p.PlataformaId == id);
        }
    }
}
