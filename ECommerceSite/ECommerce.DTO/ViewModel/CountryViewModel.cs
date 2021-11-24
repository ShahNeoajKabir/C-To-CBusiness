using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DTO.ViewModel
{
    public class CountryViewModel
    {
        public int Id { get; set; }
        [Required]
        public string CountryName { get; set; }
        public int Status { get; set; }
    }
}
