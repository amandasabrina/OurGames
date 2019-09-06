using Microsoft.EntityFrameworkCore;
using OurGames.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OurGames.Repository
{
    public class PlataformRepository : AbstractRepository<Plataform>
    {
        public PlataformRepository(DbContextOptions<OurGamesContext> contextOptions) : base(contextOptions)
        {
        }

        public override List<Plataform> GetAll()
        {
            return db.Plataform.ToList();
        }

        public override Plataform GetById(int id)
        {
            return db.Plataform.FirstOrDefault(p => p.PlataformId == id);
        }
    }
}
