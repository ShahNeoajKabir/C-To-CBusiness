using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DTO.DTO
{
    public class City
    {
        public int Id { get; set; }
        public string  CityName{ get; set; }
        public int DivisionId { get; set; }
        public Division Division { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
        public ICollection<State> State { get; set; }
        public virtual ICollection<AppUser> AppUser { get; set; }
    }
}
