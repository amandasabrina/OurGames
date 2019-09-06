using System;
using System.Collections.Generic;

namespace OurGames.Core.Model
{
    public partial class LoginMethod
    {
        public LoginMethod()
        {
            Customer = new HashSet<Customer>();
        }

        public int LoginMethodId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}