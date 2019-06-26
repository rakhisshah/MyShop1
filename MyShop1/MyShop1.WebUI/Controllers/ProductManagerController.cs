﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop1.core.Models;
using MyShop1.DataAccess.InMemory;

namespace MyShop1.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        ProductRepository context;
        public ProductManagerController()

        {
            context = new ProductRepository();
            

        }
        // GET: ProductManager
        public ActionResult Index()
        {
            List<Product> products = context.collection().ToList();

            return View(products);
        }
        public ActionResult Create()
        {
            Product product = new Product();
            return View(product);
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if(!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                context.Insert(product);
                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(String id)
        {
            Product product = context.Find(id);
            if(product==null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
        }
        [HttpPost]
        public ActionResult Edit(Product product,string id)
        {
            Product ProductToEdit = context.Find(id);
            if (ProductToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }
                ProductToEdit.Category = product.Category;
                ProductToEdit.Description = product.Description;
                ProductToEdit.Image = product.Image;
                ProductToEdit.Name = product.Name;
                ProductToEdit.Price = product.Price;
                context.Commit();
                return RedirectToAction("Index");

            }
        } 
        public ActionResult Delete(string id)
        {
            Product ProductToDelete = context.Find(id);
            if (ProductToDelete==null)
            {
                return HttpNotFound();

            }
            else
            {
                return View(ProductToDelete);

            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {

            Product ProductToDelete = context.Find(id);
            if (ProductToDelete == null)
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