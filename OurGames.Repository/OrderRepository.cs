using Microsoft.EntityFrameworkCore;
using OurGames.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OurGames.Repository
{
    public class OrderRepository : AbstractRepository<Pedido>
    {
        public OrderRepository(DbContextOptions<OurGamesContext> contextOptions) : base(contextOptions)
        {
        }

        public override IEnumerable<Pedido> GetAll()
        {
            return db.Pedido.ToList();
        }

        public override Pedido GetById(int id)
        {
            return db.Pedido.FirstOrDefault(p => p.PedidoId == id);
        }
    }
}
