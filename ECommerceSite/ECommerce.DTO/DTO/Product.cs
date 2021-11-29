using ECommerce.DTO.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DTO.DTO
{
    public class Product:BaseModel
    {
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string ProductTitle { get; set; }
        public string ProductCode { get; set; }
        public string Features { get; set; }
        public string Description { get; set; }
        public string Authenticity { get; set; } // if electic original or chaina if cloths which type
        public decimal NormalPrice { get; set; }
        public int Stock { get; set; }
        public decimal? DiscountPercentige { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<ProductPhoto> ProductPhoto { get; set; }
        public Brand Brand { get; set; }
        public Category  Category { get; set; }
        public SubCategory  SubCategory { get; set; }
        public ICollection<ProductColor> ProductColor { get; set; }
        public ICollection<ProductSize>  ProductSize { get; set; }
    }
}
