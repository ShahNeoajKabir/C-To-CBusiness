using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DTO.DTO
{
    public class Division
    {
        public int Id { get; set; }
        public string DivisionName { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
        public ICollection<City> City { get; set; }
        public virtual ICollection<AppUser> AppUser { get; set; }
    }
}
