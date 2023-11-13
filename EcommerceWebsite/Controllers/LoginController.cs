using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceWebsite.EntityFramework;

namespace EcommerceWebsite.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User user)
        {
            var database = new EcommerceWebsiteDatabseEntities();
            var userData = database.Users.FirstOrDefault(u => u.Email == user.Email);
            if (userData != null)
            {
                if (userData.Password == user.Password)
                {
                    Session["UserID"] = userData.Id;
                    switch (userData.Role)
                    {
                        case "Admin":
                            return RedirectToAction("Index", "AdminDashboard");
                        case "Buyer":
                            return RedirectToAction("Index", "CustomerDashboard");
                        default:
                            return RedirectToAction("Index", "SellerDashboard");
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}