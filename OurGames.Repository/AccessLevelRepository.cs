using Microsoft.EntityFrameworkCore;
using OurGames.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OurGames.Repository
{
    public class AccessLevelRepository : AbstractRepository<AccessLevel>
    {
        public AccessLevelRepository(DbContextOptions<OurGamesContext> contextOptions) : base(contextOptions)
        {
        }

        public override List<AccessLevel> GetAll()
        {
            return db.AccessLevel.ToList();
        }

        public override AccessLevel GetById(int id)
        {
            return db.AccessLevel.FirstOrDefault(n => n.AccessLevelId == id);
        }
    }
}
