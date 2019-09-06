using System;
using System.Collections.Generic;

namespace OurGames.Core.Model
{
    public partial class Plataform
    {
        public Plataform()
        {
            Product = new HashSet<Product>();
        }

        public int PlataformId { get; set; }
        public string PlataformName { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}