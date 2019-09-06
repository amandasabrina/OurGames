using System;
using System.Collections.Generic;

namespace OurGames.Core.Model
{
    public partial class Customer
    {
        public Customer()
        {
            Address = new HashSet<Address>();
            Order = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string Phone { get; set; }
        public string Cpf { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int LoginMethodId { get; set; }
        public int AccessLevelId { get; set; }
        public bool Active { get; set; }

        public virtual AccessLevel AccessLevel { get; set; }
        public virtual LoginMethod LoginMethod { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}