using Microsoft.EntityFrameworkCore;
using OurGames.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OurGames.Repository
{
    public class ProductRepository : AbstractRepository<Produto>
    {
        public ProductRepository(DbContextOptions<OurGamesContext> contextOptions) : base(contextOptions)
        {
        }

        public override List<Produto> GetAll()
        {
            return db.Produto.ToList();
        }

        public override Produto GetById(int id)
        {
            return db.Produto.FirstOrDefault(p => p.ProdutoId == id);
        }
    }
}
