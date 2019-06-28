using MyShop1.core.Models;
using MyShop1.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop1.WebUI.Controllers
{
    public class ProductCategoryManegerController : Controller
    {
        ProductCategoryRepositery context;
        public ProductCategoryManegerController()

        {
            context = new ProductCategoryRepositery();

        }
        // GET: ProductManager
        public ActionResult Index()
        {
            List<ProductCategory> productCategories = context.collection().ToList();

            return View(productCategories);
        }
        public ActionResult Create()
        {
            ProductCategory productCategory = new ProductCategory();
            return View(productCategory);
        }
        [HttpPost]
        public ActionResult Create(ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(productCategory);
            }
            else
            {
                context.Insert(productCategory);
                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(String id)
        {
            ProductCategory productCategory = context.Find(id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCategory);
            }
        }
        [HttpPost]
        public ActionResult Edit(ProductCategory productCategory, string id)
        {
            ProductCategory ProductCategoryToEdit = context.Find(id);
            if (ProductCategoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(productCategory);
                }
                ProductCategoryToEdit.Category = productCategory.Category;
                
                context.Commit();
                return RedirectToAction("Index");

            }
        }
        public ActionResult Delete(string id)
        {
            ProductCategory ProductCategoryToDelete = context.Find(id);
            if (ProductCategoryToDelete == null)
            {
                return HttpNotFound();

            }
            else
            {
                return View(ProductCategoryToDelete);

            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {

            ProductCategory ProductCategoryToDelete = context.Find(id);
            if (ProductCategoryToDelete == null)
            {
                return HttpNotFound();

            }
            else
            {
                context.Delete(id);
                context.Commit();
                return RedirectToAction("Index");

            }
        }
    }
}