using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CTSImp1.Facade;
using CTSImp1.Models;
using CTSImp1.ViewModels;

namespace CTSImp1
{
    public class ComplaintController : Controller
    {
        // GET: Complaint
        public ActionResult Index()
        {
            CorrCompContactInfo corrCompContactInfo = new CorrCompContactInfo();
            return View("ComplaintPV");
        }
    }
}