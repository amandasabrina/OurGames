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

        public static AddressViewModel Map(Address entity)
        {
            return new AddressViewModel
            {
                AddressId = entity.AddressId,
                CEP = entity.Cep,
                City = entity.City,
                Number = entity.Number,
                Street = entity.Street,
                UF = entity.Uf
            };
        }
    }
}
