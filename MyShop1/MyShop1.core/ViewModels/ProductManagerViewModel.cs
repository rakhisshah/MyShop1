using MyShop1.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop1.core.ViewModels
{
    public class ProductManagerViewModel
    {
        public Product product { get; set; }
        public IEnumerable<ProductCategory>ProductCategories{get;set;}
    }

}
