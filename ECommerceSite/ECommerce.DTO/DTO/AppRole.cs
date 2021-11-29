using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.DTO.DTO
{
    public class AppRole:IdentityRole<int>
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
        public ICollection<AppUserRole> UserRole { get; set; }
        public ICollection<UserPhoto>  UserPhotos { get; set; }
    }
}
