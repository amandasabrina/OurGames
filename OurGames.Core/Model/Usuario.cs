using System;
using System.Collections.Generic;

namespace OurGames.Core.Model
{
    public partial class Usuario
    {
        public Usuario()
        {
            Endereco = new HashSet<Endereco>();
            Pedido = new HashSet<Pedido>();
        }

        public int UsuarioId { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public int? NivelAcessoId { get; set; }
        public string Telefone { get; set; }

        public virtual NivelAcesso NivelAcesso { get; set; }
        public virtual ICollection<Endereco> Endereco { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}