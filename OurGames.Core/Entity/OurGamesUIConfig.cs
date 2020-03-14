using System;
using System.Collections.Generic;
using System.Text;

namespace OurGames.Core.Entity
{
    public class OurGamesUIConfig
    {
        public string PagSeguroEmail { get; set; }
        public string PagSeguroToken { get; set; }
        public string PagSeguroUrl { get; set; }
        public EmailSettings EmailSettings { get; set; }
        public string SuportEmail { get; set; }
    }

    public class EmailSettings
    {
        public string From { get; set; }
        public string DeliveryMethod { get; set; }
        public int Port { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public string DisplayName { get; set; }
        public bool EnableSsl { get; set; }
    }
}
