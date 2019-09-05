using Microsoft.EntityFrameworkCore;
using OurGames.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OurGames.Repository
{
    public class UserRepository : AbstractRepository<Usuario>
    {
        public UserRepository(DbContextOptions<OurGamesContext> contextOptions) : base(contextOptions)
        {
        }

        public override IEnumerable<Usuario> GetAll()
        {
            return db.Usuario
                .Include(u => u.NivelAcesso)
                .ToList();
        }

        public override Usuario GetById(int id)
        {
            return db.Usuario.FirstOrDefault(u => u.UsuarioId == id);
        }
    }
}
