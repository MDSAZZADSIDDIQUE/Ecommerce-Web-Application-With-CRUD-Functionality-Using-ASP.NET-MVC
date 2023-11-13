using System.Web;
using System.Web.Mvc;

namespace EcommerceWebsite.Auth
{
    public class Logged : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["UserId"] != null) return true;
            return false;
        }
    }
}