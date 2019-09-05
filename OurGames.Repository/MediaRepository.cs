using Microsoft.EntityFrameworkCore;
using OurGames.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OurGames.Repository
{
    public class MediaRepository : AbstractRepository<Media>
    {
        public MediaRepository(DbContextOptions<OurGamesContext> contextOptions) : base(contextOptions)
        {
        }

        public override IEnumerable<Media> GetAll()
        {
            return db.Media.ToList();
        }

        public override Media GetById(int id)
        {
            return db.Media.FirstOrDefault(m => m.MediaId == id);
        }
    }
}
