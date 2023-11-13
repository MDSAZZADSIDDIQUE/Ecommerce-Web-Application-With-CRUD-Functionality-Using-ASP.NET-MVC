using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceWebsite.EntityFramework;

namespace EcommerceWebsite.Controllers
{
    public class SellerDashboardController : Controller
    {
        // GET: Seller
        public ActionResult Index()
        {
            var database = new EcommerceWebsiteDatabseEntities();
            var data = database.Products.ToList();
            return View(data);
        }
        public ActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            var database = new EcommerceWebsiteDatabseEntities();
            database.Products.Add(product);
            database.SaveChanges();
            return RedirectToAction("Index", "SellerDashboard");
        }
    }
}