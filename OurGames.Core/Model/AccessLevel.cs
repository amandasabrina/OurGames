using System;
using System.Collections.Generic;

namespace OurGames.Core.Model
{
    public partial class AccessLevel
    {
        public AccessLevel()
        {
            Customer = new HashSet<Customer>();
        }

        public int AccessLevelId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}