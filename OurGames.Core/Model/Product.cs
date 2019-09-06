using System;
using System.Collections.Generic;

namespace OurGames.Core.Model
{
    public partial class Product
    {
        public Product()
        {
            Media = new HashSet<Media>();
            OrderProduct = new HashSet<OrderProduct>();
        }

        public int ProductId { get; set; }
        public string Synopsis { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public DateTime? LaunchDate { get; set; }
        public string Category { get; set; }
        public string Requirements { get; set; }
        public int PlataformId { get; set; }
        public string Ranking { get; set; }

        public virtual Plataform Plataform { get; set; }
        public virtual ICollection<Media> Media { get; set; }
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
    }
}