using System;
using System.Collections.Generic;

namespace OurGames.Core.Model
{
    public partial class Endereco
    {
        public int EnderecoId { get; set; }
        public string Logradouro { get; set; }
        public string Cep { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}