using OurGames.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OurGames.UI.Models
{
    public class AddressViewModel
    {
        public int AddressId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Street { get; set; }

        [Required]
        [MaxLength(9)]
        public string CEP { get; set; }

        [MaxLength(2)]
        public string UF { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        [Required]
        public int Number { get; set; }

        public static AddressViewModel Map(Endereco entity)
        {
            return new AddressViewModel
            {
                AddressId = entity.EnderecoId,
                CEP = entity.Cep,
                City = entity.Cidade,
                Number = entity.Numero,
                Street = entity.Logradouro,
                UF = entity.Uf
            };
        }
    }
}
