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
    public class SearchController : Controller
    {
        #region "Unitofwork Reference"

        ISearchCTSBO _searchCTSBO = null;

        public SearchController(ISearchCTSBO searchCTSBO)
        {
            this._searchCTSBO = searchCTSBO;
        }
        public SearchController()
        {
            _searchCTSBO = new SearchCTSBO();
        }

        #endregion
        // GET: Search
        public ActionResult DisplayData(string searchterm = "")
        {
            List<CorrCompInfo> gridData = new List<CorrCompInfo>();
            gridData = _searchCTSBO.GetAllTickets();
            return View(gridData);
        }
    }
}