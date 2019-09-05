using System;
using System.Collections.Generic;

namespace OurGames.Core.Model
{
    public partial class Media
    {
        public int MediaId { get; set; }
        public string Endereco { get; set; }
        public int ProdutoId { get; set; }

        public virtual Produto Produto { get; set; }
    }
}