using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DTO.DTO
{
    public class State
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public int CityId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
        public City City { get; set; }
        public virtual ICollection<AppUser> AppUser { get; set; }
    }
}
