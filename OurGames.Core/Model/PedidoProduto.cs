using System;
using System.Collections.Generic;

namespace OurGames.Core.Model
{
    public partial class PedidoProduto
    {
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }

        public virtual Pedido Pedido { get; set; }
        public virtual Produto Produto { get; set; }
    }
}