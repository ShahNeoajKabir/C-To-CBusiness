using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DTO.ViewModel
{
    public class CityViewModel
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string DivisionName { get; set; }
        public string CountryName { get; set; }
        public int DivisionId { get; set; }
        public int Status { get; set; }
    }
}
