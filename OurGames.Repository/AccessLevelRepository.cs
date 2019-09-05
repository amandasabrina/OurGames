using Microsoft.EntityFrameworkCore;
using OurGames.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OurGames.Repository
{
    public class AccessLevelRepository : AbstractRepository<NivelAcesso>
    {
        public AccessLevelRepository(DbContextOptions<OurGamesContext> contextOptions) : base(contextOptions)
        {
        }

        public override List<NivelAcesso> GetAll()
        {
            return db.NivelAcesso.ToList();
        }

        public override NivelAcesso GetById(int id)
        {
            return db.NivelAcesso.FirstOrDefault(n => n.NivelAcessoId == id);
        }
    }
}
