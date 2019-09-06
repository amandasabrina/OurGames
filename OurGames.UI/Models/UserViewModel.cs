using Microsoft.AspNetCore.Http;
using OurGames.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OurGames.UI.Models
{
    public class UserViewModel
    {
        public int UserId { get; set; }

        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MaxLength(15)]
        public string Phone { get; set; }

        public string AvatarUrl { get; set; }
        public IFormFile AvatarFile { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
        public List<AddressViewModel> Addresses { get; set; }
        public AccessLevel AccessLevel { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [MaxLength(11)]
        public string CPF { get; set; }

        public static UserViewModel Map(Customer entity)
        {
            return new UserViewModel
            {
                UserId = entity.CustomerId,
                AccessLevel = entity.AccessLevel,
                Addresses = entity.Address.ToList().ConvertAll(e => AddressViewModel.Map(e)),
                AvatarUrl = entity.Avatar,
                BirthDate = entity.BirthDate,
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Phone = entity.Phone
            };
        }
    }   
}
