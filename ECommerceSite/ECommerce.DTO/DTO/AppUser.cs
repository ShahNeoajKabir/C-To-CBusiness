using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerce.DTO.DTO
{
    public class AppUser:IdentityUser<int>
    {
        public DateTime DateOfBirth { get; set; }
        public int StateId { get; set; }
        public int Gender { get; set; }
        public int CityId { get; set; }
        public int DivisionId { get; set; }
        public int CountryId { get; set; }
        public State State { get; set; }
        public City City { get; set; }
        public Division Division { get; set; }
        public Country Country { get; set; }
        [NotMapped]
        public int Role { get; set; }
        public ICollection<UserPhoto> UserPhoto { get; set; }
        public ICollection<AppUserRole> UserRole { get; set; }
    }
}
