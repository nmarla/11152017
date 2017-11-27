using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CTSImp1.Facade;
using CTSImp1.Models;
using CTSImp1.ViewModels;
using System.IO;


namespace CTSImp1.Controllers
{
    public class TrackingController : Controller
    {

        //
        // GET: /Tracking/
        #region "Unitofwork Reference"

        ITrackingBO _tackingBO = null;

        public TrackingController(ITrackingBO tackingBO)
        {
            this._tackingBO = tackingBO;
        }
        public TrackingController()
        {
            _tackingBO = new TrackingBO();
        }

        #endregion
        //Global variables
        bool newReferal = false;
        /// <summary>
        /// Tracking view display
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        //[RequireAuthentication]
        public ActionResult TrackingInfo()
        {
            // CorrCompInfo corrcominfo = new CorrCompInfo();
            //   int ccno = _tackingBO.GetLastccnumber(corrcominfo);
            //  corrcominfo.cc_number = ccno + 1;
            Session["ccnum"] = null;
            FillDropdowndata();
            //return View();
            UserInfo userInfo = new UserInfo();
            string currentUser = User.Identity.Name.Split('\\')[1];
            userInfo.users_id = currentUser;
            TrackingViewModel trackingVM = new TrackingViewModel();
            //   trackingVM.corrcmpInfo = corrcominfo;
            trackingVM.userInfom = userInfo;
            return View("Tracking", trackingVM);
        }
        /// <summary>
        /// Tracking view submit
        /// </summary>
        /// <param name="tackingviewmodel"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
       // [RequireAuthentication]
        public ActionResult TrackingInfo(TrackingViewModel tackingviewmodel)
        {
            TrackingViewModel trackingVM = new TrackingViewModel();
            FillDropdowndata();
            if (Session["ccnum"] == null)
            {
                _tackingBO.InsertData(tackingviewmodel);
                ModelState.Clear();
                CorrCompInfo corrcominfo = new CorrCompInfo();
                int ccno = _tackingBO.GetLastccnumber(corrcominfo);
                trackingVM.corrcmpInfo = _tackingBO.GetCCTKTByccno(ccno); ;
                trackingVM.userInfom = _tackingBO.GetUserDetailsForID(trackingVM.corrcmpInfo.recd_by);
                Session["ccnum"] = ccno;
                return View("Tracking", trackingVM);
            }
            else
            {
                int ccno = Convert.ToInt32(Session["ccnum"]);
                trackingVM.corrcmpInfo = _tackingBO.GetCCTKTByccno(ccno); ;
                return View("Tracking", trackingVM);
            }
        }


        /// <summary>
        /// Get tracking view for existing record
        /// </summary>
        /// <param name="ccno"></param>
        /// <returns></returns>
        [Authorize]
       // [RequireAuthentication]
        public ActionResult DetailReport(int ccno)
        {
            TrackingViewModel trackingVM = new TrackingViewModel();
            Session["ccnum"] = ccno;
            FillDropdowndata();
            trackingVM.corrcmpInfo = _tackingBO.GetCCTKTByccno(ccno);
            trackingVM.corrcmpcontactInfo = _tackingBO.GetCCCNTInfo(ccno);
            trackingVM.inclocationinfo = _tackingBO.GetCCDetailsInfo(ccno);
            trackingVM.ccDescInfo = _tackingBO.GetCCCommentsInfo(ccno);
            trackingVM.referralInfom = _tackingBO.GetCCReferralInfo(ccno);
            trackingVM.resolutionInfom = _tackingBO.GetCCResolutionInfo(ccno);
            trackingVM.documentsInfom = _tackingBO.GetCCAttachmentsInfo(ccno);
            return View("Tracking", trackingVM);
        }

        /// <summary>
        /// Save complaint/inquiry tab information to DB
        /// </summary>
        /// <param name="trackcomplaint"></param>
        /// <returns></returns>
        [HttpPost]
       // [RequireAuthentication]
        public ActionResult SaveComplaintInfo(TrackingViewModel trackcomplaint)
        {
            // TrackingViewModel trckingvm = new TrackingViewModel();
             int ccno = Convert.ToInt32(Session["ccnum"]);
            //if (!string.IsNullOrEmpty(trackcomplaint.corrcmpInfo.cc_number.ToString()))
            //{
                int UserId = _tackingBO.GetUserIDFromUserInfo(trackcomplaint);
                _tackingBO.InsertUpdateCCCNTInfo(trackcomplaint, ccno, UserId);
                FillDropdowndata();
                return View("Tracking", trackcomplaint);
            //}
            //else
            //{
            //    return View("Tracking");
            //}
        }
        /// <summary>
        /// Save Details tab information to DB
        /// </summary>
        /// <param name="trackdetails"></param>
        /// <returns></returns>
        [HttpPost]
       // [RequireAuthentication]
        public ActionResult SaveDetailsInfo(TrackingViewModel trackdetails)
        {
            // TrackingViewModel trckingvm = new TrackingViewModel();
             int ccno = Convert.ToInt32(Session["ccnum"]);
            //if (!string.IsNullOrEmpty(trackdetails.corrcmpInfo.cc_number.ToString()))
            //{
                int UserId = _tackingBO.GetUserIDFromUserInfo(trackdetails);
                _tackingBO.InsertUpdateCCDetailsInfo(trackdetails, ccno, UserId);
                _tackingBO.InsertUpdateCorrCompDescResolution(trackdetails, ccno, UserId);
                FillDropdowndata();
                return View("Tracking", trackdetails);
            //}
            //else
            //{
            //    return View("Tracking");
            //}
        }
        /// <summary>
        /// Save Referral tab information to DB
        /// </summary>
        /// <param name="trackreferral"></param>
        /// <returns></returns>
        [HttpPost]
       // [RequireAuthentication]
        public ActionResult SaveReferralInfo(TrackingViewModel trackreferral)
        {
            //if (!string.IsNullOrEmpty(trackreferral.corrcmpInfo.cc_number.ToString()))
            //{
            int ccno = Convert.ToInt32(Session["ccnum"]);
            if (newReferal)
            {
                int UserId = _tackingBO.GetUserIDFromUserInfo(trackreferral);
                _tackingBO.InsertCCReferralInfo(trackreferral, ccno, UserId);
                FillDropdowndata();                
                return View("Tracking", trackreferral);
            }
            else
            {
                int UserId = _tackingBO.GetUserIDFromUserInfo(trackreferral);
                _tackingBO.InsertUpdateCCReferralInfo(trackreferral, ccno, UserId);
                FillDropdowndata();
                return View("Tracking", trackreferral);
            }
            //}
            //else
            //{
            //    return View("Tracking");
            //}
        }

        [HttpPost]
        public ActionResult AddNewReferral(TrackingViewModel trackreferral)
        {
            newReferal = true;
            return View("Tracking", trackreferral);
        }
        /// <summary>
        /// Save Resolution tab information to DB
        /// </summary>
        /// <param name="trackresolution"></param>
        /// <returns></returns>
        [HttpPost]
       // [RequireAuthentication]
        public ActionResult SaveResolutionInfo(TrackingViewModel trackresolution)
        {
            try
            {
                //if (!string.IsNullOrEmpty(trackresolution.corrcmpInfo.cc_number.ToString()))
                //{
                int ccno = Convert.ToInt32(Session["ccnum"]);
                int UserId = _tackingBO.GetUserIDFromUserInfo(trackresolution);
                    _tackingBO.InsertUpdateCCResolutionInfo(trackresolution, trackresolution.corrcmpInfo.cc_number, UserId);
                    _tackingBO.InsertUpdateCorrCompDescResolution(trackresolution, trackresolution.corrcmpInfo.cc_number, UserId);
                    FillDropdowndata();
                    return View("Tracking", trackresolution);
                //}
                //else
                //{
                //    return View("Tracking");
                //}
            }
            catch (Exception ex)
            {
                return View("Tracking");
            }
        }
        /// <summary>
        /// Save Attachments tab info
        /// </summary>
        /// <param name="trackattachment"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
       // [RequireAuthentication]
        public ActionResult SaveAttachmentsInfo(TrackingViewModel trackattachment, HttpPostedFileBase file)
        {
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    int ccno = Convert.ToInt32(Session["ccnum"]);
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Server.MapPath("~/Uploads/");
                    if (!Directory.Exists(_path))
                    {
                        Directory.CreateDirectory(_path);
                    }
                    _path = Path.Combine(_path, _FileName);
                    file.SaveAs(_path);
                    trackattachment.documentsInfom.file_name = _FileName;
                    trackattachment.documentsInfom.file_ext = Path.GetExtension(file.FileName);
                    trackattachment.documentsInfom.file_location = _path;
                    int UserId = _tackingBO.GetUserIDFromUserInfo(trackattachment);
                    _tackingBO.InsertUpdateDocumentsInfo(trackattachment, ccno, UserId);
                    FillDropdowndata();
                    return View("Tracking", trackattachment);
                }
                else
                {
                    return View("Tracking");
                }
            }
            catch (Exception ex)
            {
                return View("Tracking");
            }
        }

        /// <summary>
        /// Getting dropdown data from CTSCode table 
        /// </summary>
        public void FillDropdowndata()
        {
            List<CTSCodeTable> items = new List<CTSCodeTable>();
            items = _tackingBO.GetItemsfordropdownsctscodetable();
            ViewData["ComplaintEnquiry"] = items.Where(s => s.table_no.Equals(110)).ToList();
            ViewData["PurposeOfContact"] = items.Where(s => s.table_no.Equals(100)).ToList();
            ViewData["ComplaintStatus"] = items.Where(s => s.table_no.Equals(120)).ToList();
            ViewData["ContractwithDFTA"] = items.Where(s => s.table_no.Equals(210)).ToList();
            ViewData["IncidentLocation"] = items.Where(s => s.table_no.Equals(150)).ToList();
            ViewData["ReferredTo"] = items.Where(s => s.table_no.Equals(160)).ToList();
            ViewData["ReferredStatus"] = items.Where(s => s.table_no.Equals(170)).ToList();
            ViewData["ResolutionHandledBy"] = items.Where(s => s.table_no.Equals(180)).ToList();
            ViewData["ResolutionStatus"] = items.Where(s => s.table_no.Equals(190)).ToList();
            ViewData["Category"] = items.Where(s => s.table_no.Equals(200)).ToList();
            //budget table program type
            //List<BudgetCodeModel> itemsPT = new List<BudgetCodeModel>();
            //itemsPT = _tackingBO.GetBudgetProgramType(873);
            //ViewData["BudgetProgramType"] = itemsPT;
            ////budget type program ID
            //List<BudgetCodeModel> itemsPID = new List<BudgetCodeModel>();
            //itemsPID = _tackingBO.GetBudgetProgramID(itemsPT[0].data_value);
            //ViewData["BudgetProgramID"] = itemsPID;


        }


    }
}
