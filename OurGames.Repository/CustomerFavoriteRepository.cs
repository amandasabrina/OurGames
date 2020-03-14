using Microsoft.EntityFrameworkCore;
using OurGames.Core.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OurGames.Repository
{
    public class CustomerFavoriteRepository : AbstractRepository<CustomerFavorite>
    {
        public CustomerFavoriteRepository(DbContextOptions<OurGamesContext> dbContextOptions) : base(dbContextOptions)
        {
        }
    }
}
