using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OurGames.UI.Models
{
    public class UserViewModel
    {
        [Required]
        public string Uid { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
