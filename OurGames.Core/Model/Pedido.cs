using System;
using System.Collections.Generic;

namespace OurGames.Core.Model
{
    public partial class Pedido
    {
        public Pedido()
        {
            PedidoProduto = new HashSet<PedidoProduto>();
        }

        public int PedidoId { get; set; }
        public DateTime Data { get; set; }
        public int Valor { get; set; }
        public int? Quantidade { get; set; }
        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<PedidoProduto> PedidoProduto { get; set; }
    }
}