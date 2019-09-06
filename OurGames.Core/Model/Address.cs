using System;
using System.Collections.Generic;

namespace OurGames.Core.Model
{
    public partial class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string Cep { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string Uf { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}