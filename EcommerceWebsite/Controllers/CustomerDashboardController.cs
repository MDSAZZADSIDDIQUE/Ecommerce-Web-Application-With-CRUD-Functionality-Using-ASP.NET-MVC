using EcommerceWebsite.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceWebsite.Controllers
{
    public class CustomerDashboardController : Controller
    {
        // GET: CustomerDashboard
        public ActionResult Index()
        {
            var database = new EcommerceWebsiteDatabseEntities();
            var data = database.Products.ToList();
            return View(data);
        }
        public ActionResult AddToCart(int Id)
        {
            var database = new EcommerceWebsiteDatabseEntities();
            var cart = new Cart()
            {
                CustomerID = (int)Session["userID"],
                ProductID = Id,
                Quantity = 1
            };
            database.Carts.Add(cart);
            database.SaveChanges();
            return RedirectToAction("Index", "CustomerDashboard");
        }
    }
}