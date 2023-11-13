using EcommerceWebsite.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceWebsite.Controllers
{
    public class AdminDashboardController : Controller
    {
        // GET: AdminDashboard
        public ActionResult Index()
        {
            var database = new EcommerceWebsiteDatabseEntities();
            var data = database.Users.ToList();
            return View(data);
        }
    }
}