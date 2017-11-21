using LoginAD.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginAD.Security
{
    public class RequireAuthentication : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if(HttpContext.Current.Session["IsAuthenticated"] == null || !Convert.ToBoolean(HttpContext.Current.Session["IsAuthenticated"]))
            {
                var baseController = (BaseController)filterContext.Controller;
                filterContext.Result = baseController.RedirectToAction("login", "login");
            }
        }
    }
}