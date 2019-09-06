using Microsoft.EntityFrameworkCore;
using OurGames.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OurGames.Repository
{
    public class ProductRepository : AbstractRepository<Product>
    {
        public ProductRepository(DbContextOptions<OurGamesContext> contextOptions) : base(contextOptions)
        {
        }

        public override List<Product> GetAll()
        {
            return db.Product.ToList();
        }

        public override Product GetById(int id)
        {
            return db.Product.FirstOrDefault(p => p.ProductId == id);
        }
    }
}
