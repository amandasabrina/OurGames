using Microsoft.EntityFrameworkCore;
using OurGames.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OurGames.Repository
{
    public class OrderRepository : AbstractRepository<Order>
    {
        public OrderRepository(DbContextOptions<OurGamesContext> contextOptions) : base(contextOptions)
        {
        }

        public override List<Order> GetAll()
        {
            return db.Order.ToList();
        }

        public override Order GetById(int id)
        {
            return db.Order.FirstOrDefault(p => p.OrderId == id);
        }
    }
}
