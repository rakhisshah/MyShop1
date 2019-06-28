using MyShop1.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop1.DataAccess.InMemory
{
    public class ProductCategoryRepositery
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategories = new List<ProductCategory>();
        public ProductCategoryRepositery()
        {
            productCategories = cache["productCategories"] as List<ProductCategory>;
            if (productCategories == null)
            {
                productCategories = new List<ProductCategory>();


            }
        }
        public void Commit()
        {
            cache["productCategories"] = productCategories;
        }
        public void Insert(ProductCategory p)

        {
            productCategories.Add(p);
        }
        public void Update(ProductCategory productCategory)
        {
            ProductCategory ProductCategoryToUpdate = productCategories.Find(p => p.Id == productCategory.Id);
            if (ProductCategoryToUpdate != null)
            {
                ProductCategoryToUpdate = productCategory;
            }
            else
            {
                throw new Exception("Product Category Nnot Found");
            }
        }
        public ProductCategory Find(string id)
        {
            ProductCategory product = productCategories.Find(p => p.Id == id);
            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Product Category Not Found");
            }

        }
        public IQueryable<ProductCategory> collection()
        {
            return productCategories.AsQueryable();
        }
        public void Delete(string id)
        {
            ProductCategory  ProductCategoryToDelete = productCategories.Find(p => p.Id == id);
            if (ProductCategoryToDelete != null)
            {
                productCategories.Remove(ProductCategoryToDelete);
            }
            else
            {
                throw new Exception("Product Category Nnot Found");
            }
        }

    }
}
