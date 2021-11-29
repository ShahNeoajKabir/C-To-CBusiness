using ECommerce.DTO.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DTO.DTO
{
    public class Size:BaseModel
    {
        public string SizeName { get; set; }
        public ICollection<ProductColor> ProductColor { get; set; }

    }
}
