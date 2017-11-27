using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CTSImp1.Facade;
using CTSImp1.Models;
using CTSImp1.ViewModels;

namespace CTSImp1.Controllers
{
    public class UserDetailsController : Controller
    {
        #region "Unitofwork Reference"

        ITrackingBO _tackingBO = null;

        public UserDetailsController(ITrackingBO tackingBO)
        {
            this._tackingBO = tackingBO;
        }
        public UserDetailsController()
        {
            _tackingBO = new TrackingBO();
        }

        #endregion
        // GET: UserDetails
        public ActionResult Index()
        {
            string currentUser = User.Identity.Name;
            currentUser = currentUser.Split('\\')[1];
            UserInfo userinfo = new UserInfo();
            List<UserInfo> userDetails = new List<UserInfo>();
            userDetails = _tackingBO.GetAllUserDetails(currentUser);
            userinfo.first_name = userDetails[0].first_name;
            userinfo.last_name = userDetails[0].last_name;
            return View("WelcomeSearchPV", userinfo);
        }
    }
}