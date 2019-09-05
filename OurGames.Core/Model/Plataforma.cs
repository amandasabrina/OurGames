using System;
using System.Collections.Generic;

namespace OurGames.Core.Model
{
    public partial class Plataforma
    {
        public Plataforma()
        {
            Produto = new HashSet<Produto>();
        }

        public int PlataformaId { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Produto> Produto { get; set; }
    }
}