using Microsoft.EntityFrameworkCore;
using OurGames.Core.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OurGames.Repository
{
    public class OrderRepository : AbstractRepository<Order>
    {
        public OrderRepository(DbContextOptions<OurGamesContext> dbContextOptions) : base(dbContextOptions)
        {
        }
    }
}
