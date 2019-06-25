using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop1.core;
using MyShop1.core.Models;

namespace MyShop1.DataAccess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products = new List<Product>();
        public ProductRepository()
        {
            products = cache["products"] as List<Product>;
            if(products==null)
            {
                products = new List<Product>();


            }
        }
        public void Commit()
        {
            cache["products"] = products;
        }
        public void Insert(Product p)

        {
            products.Add(p);
        }
        public void Update(Product product)
        {
            Product ProductToUpdate = products.Find(p => p.Id == product.Id);
            if(ProductToUpdate!=null)
            {
                ProductToUpdate = product;
            }
            else
            {
                throw new Exception("Product Nnot Found");
            }
        }
        public Product Find(string id)
        {
            Product product = products.Find(p => p.Id == id);
            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Product Nnot Found");
            }

        }
        public IQueryable<Product>collection()
        {
            return products.AsQueryable();
        }
        public void Delete(string id)
        {
            Product ProductToDelete= products.Find(p => p.Id == id);
            if (ProductToDelete != null)
            {
                products.Remove(ProductToDelete);
            }
            else
            {
                throw new Exception("Product Nnot Found");
            }
        }

    }
}
