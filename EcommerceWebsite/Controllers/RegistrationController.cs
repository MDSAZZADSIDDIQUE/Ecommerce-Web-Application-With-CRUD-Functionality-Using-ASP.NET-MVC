using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceWebsite.EntityFramework;

namespace EcommerceWebsite.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            var database = new EcommerceWebsiteDatabseEntities();
            database.Users.Add(user);
            database.SaveChanges();
            Session["UserID"] = user.Id;
            switch (user.Role)
            {
                case "Admin":
                    return RedirectToAction("Index", "AdminDashboard");
                case "Buyer":
                    return RedirectToAction("Index", "CustomerDashboard");
                default:
                    return RedirectToAction("Index", "SellerDashboard");
            }
        }

    }
}