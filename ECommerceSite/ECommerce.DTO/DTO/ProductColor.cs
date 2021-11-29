using ECommerce.DTO.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DTO.DTO
{
    public class ProductColor:BaseModel
    {
        public int ProducId { get; set; }
        public int ColorId { get; set; }
        public Product Product { get; set; }
        public Color Color { get; set; }
    }
}
