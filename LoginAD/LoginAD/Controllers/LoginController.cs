using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices.AccountManagement;
using LoginAD.Models;

namespace LoginAD.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {
            //LoginModel model = new LoginModel();
            string domain = ContextType.Domain.ToString();
            PrincipalContext context = new PrincipalContext(ContextType.Domain, "WORKGROUP");
            if (context.ValidateCredentials(model.UserName, model.Password))
            {
                HttpContext.Session["IsAuthenticated"] = true;
                return View("About");
            }
            return RedirectToAction("Login");
        }  
    }
}