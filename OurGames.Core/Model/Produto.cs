using System;
using System.Collections.Generic;

namespace OurGames.Core.Model
{
    public partial class Produto
    {
        public Produto()
        {
            Media = new HashSet<Media>();
            PedidoProduto = new HashSet<PedidoProduto>();
        }

        public int ProdutoId { get; set; }
        public string Sinopse { get; set; }
        public string Nome { get; set; }
        public int Preco { get; set; }
        public DateTime? Lancamento { get; set; }
        public string Categoria { get; set; }
        public string Requisitos { get; set; }
        public int PlataformaId { get; set; }
        public string Classificacao { get; set; }

        public virtual Plataforma Plataforma { get; set; }
        public virtual ICollection<Media> Media { get; set; }
        public virtual ICollection<PedidoProduto> PedidoProduto { get; set; }
    }
}