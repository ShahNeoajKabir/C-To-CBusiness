using Microsoft.AspNetCore.Identity;
using System;

namespace ECommerce.DTO.DTO
{
    public class AppUserRole : IdentityUserRole<int>
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
        public AppUser User { get; set; }
        public AppRole Role { get; set; }
    }
}