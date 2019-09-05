using System;
using System.Collections.Generic;

namespace OurGames.Core.Model
{
    public partial class NivelAcesso
    {
        public NivelAcesso()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int NivelAcessoId { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}