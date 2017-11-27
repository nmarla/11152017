using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTSImp1.Models;
using CTSImp1.DataLayer;
using System.Data;
using System.Data.SqlClient;
using CTSImp1.ViewModels;


namespace CTSImp1.Facade
{
    public class TrackingBO : ITrackingBO
    {
        #region "Unitofwork Reference"
        IUnitOfWork _unitOfWork = null;

        public TrackingBO(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }
        public TrackingBO()
        {
            _unitOfWork = new UnitOfWork();
        }
        #endregion

        public void InsertData(TrackingViewModel trackingviewmodel)
        {
            try
            {
                int userID = GetUserIDFromUserInfo(trackingviewmodel);
                InsertUpdateCCInfo(trackingviewmodel, userID);
            }
            catch (Exception ex)
            {
                ExceptionsBO exbo = new ExceptionsBO();
                exbo.SaveLogData(ex);
            }
        }

        public int GetUserIDFromUserInfo(TrackingViewModel trackingviewmodel)
        {
            try
            {
                UserInfo userInfo = new UserInfo();
                userInfo.users_id = trackingviewmodel.userInfom.users_id;
                List<UserInfo> items = new List<UserInfo>();
                items = GetAllUserDetails(userInfo.users_id);
                int userID = items[0].usersinfo_id;
                return userID;
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        public List<CTSCodeTable> GetItemsfordropdownsctscodetable()
        {
            try
            {
                var result = _unitOfWork.Repository<CTSCodeTable>().ExecuteProcedureForList("SP_Dropdownitems").ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int GetLastccnumber(CorrCompInfo corrcominfo)
        {
            int lastccno = 0;
            try
            {
                var result = _unitOfWork.Repository<CorrCompInfo>().ExecuteProcedureForList("SP_GetLastCCNumber").ToList();
                lastccno = Convert.ToInt32(result[0].cc_number);
                return lastccno;
            }
            catch (Exception ex)
            {
                ExceptionsBO exmsg = new ExceptionsBO();
                exmsg.SaveLogData(ex);
                return lastccno;
            }
        }

        public List<UserInfo> GetAllUserDetails(string UserID)
        {
            try
            {
                UserInfo userInfo = new UserInfo();
                var userDetails = _unitOfWork.Repository<UserInfo>().ExecuteProcedureForList("SP_UserDetails @UserID",
                           new SqlParameter("@UserID", SqlDbType.VarChar) { Value = UserID }).ToList();
                return userDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public UserInfo GetUserDetailsForID(int id)
        {
            try
            {
                UserInfo userInfo = new UserInfo();
                var userDetails = _unitOfWork.Repository<UserInfo>().ExecuteProcedureForList("SP_UserDetailsForID @usersinfo_id",
                           new SqlParameter("@usersinfo_id", SqlDbType.Int) { Value = id }).ToList();
                userInfo = userDetails[0];
                return userInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //budget table

        public List<BudgetCodeModel> GetBudgetProgramType(int tblno)
        {
            try
            {
                var budgetPT = _unitOfWork.Repository<BudgetCodeModel>().ExecuteProcedureForList("uspGetProgramType @table_no",
                           new SqlParameter("@table_no", SqlDbType.Int) { Value = tblno }).ToList();
                return budgetPT;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BudgetCodeModel> GetBudgetProgramID(string program_type)
        {
            try
            {
                var budgetPID = _unitOfWork.Repository<BudgetCodeModel>().ExecuteProcedureForList("uspGetProgramName @program_type",
                           new SqlParameter("@program_type", SqlDbType.VarChar) { Value = program_type }).ToList();
                return budgetPID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CorrCompInfo GetCCTKTByccno(int ccno)
        {
            try
            {
                CorrCompInfo corrcompinfo = new CorrCompInfo();
                var result = _unitOfWork.Repository<CorrCompInfo>().ExecuteProcedureForList("SP_GetTicketsbyccno @CCno",
                           new SqlParameter("@CCno ", SqlDbType.VarChar) { Value = ccno }).ToList();
                corrcompinfo = result[0];
                return corrcompinfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CorrCompContactInfo GetCCCNTInfo(int ccno)
        {
            try
            {
                CorrCompContactInfo ccCntInfo = new CorrCompContactInfo();
                var result = _unitOfWork.Repository<CorrCompContactInfo>().ExecuteProcedureForList("SP_GetCCCNTInfo @CCno",
                           new SqlParameter("@CCno ", SqlDbType.VarChar) { Value = ccno }).ToList();
                ccCntInfo = result[0];
                return ccCntInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IncLocationInfo GetCCDetailsInfo(int ccno)
        {
            try
            {
                IncLocationInfo ccDetailsInfo = new IncLocationInfo();
                var result = _unitOfWork.Repository<IncLocationInfo>().ExecuteProcedureForList("SP_GetCCDetailsInfo @CCno",
                           new SqlParameter("@CCno ", SqlDbType.VarChar) { Value = ccno }).ToList();
                ccDetailsInfo = result[0];
                return ccDetailsInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ReferralInfo GetCCReferralInfo(int ccno)
        {
            try
            {
                ReferralInfo ccReferalInfo = new ReferralInfo();
                var result = _unitOfWork.Repository<ReferralInfo>().ExecuteProcedureForList("SP_GetCCReferralInfo @CCno",
                           new SqlParameter("@CCno ", SqlDbType.VarChar) { Value = ccno }).ToList();
                ccReferalInfo = result[0];
                return ccReferalInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResolutionInfo GetCCResolutionInfo(int ccno)
        {
            try
            {
                ResolutionInfo ccResolutionInfo = new ResolutionInfo();
                var result = _unitOfWork.Repository<ResolutionInfo>().ExecuteProcedureForList("SP_GetCCResolutionInfo @CCno",
                           new SqlParameter("@CCno ", SqlDbType.VarChar) { Value = ccno }).ToList();
                ccResolutionInfo = result[0];
                return ccResolutionInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DocumentsInfo GetCCAttachmentsInfo(int ccno)
        {
            try
            {
                DocumentsInfo ccDocumentsInfo = new DocumentsInfo();
                var result = _unitOfWork.Repository<DocumentsInfo>().ExecuteProcedureForList("SP_GetCCAttachmentsInfo @CCno",
                           new SqlParameter("@CCno ", SqlDbType.VarChar) { Value = ccno }).ToList();
                ccDocumentsInfo = result[0];
                return ccDocumentsInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public CorrCompDescResolution GetCCCommentsInfo(int ccno)
        {
            try
            {
                CorrCompDescResolution cccommentsInfo = new CorrCompDescResolution();
                var result = _unitOfWork.Repository<CorrCompDescResolution>().ExecuteProcedureForList("SP_GetCCCommentsInfo @CCno",
                           new SqlParameter("@CCno ", SqlDbType.VarChar) { Value = ccno }).ToList();
                cccommentsInfo = result[0];
                return cccommentsInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertUpdateCCInfo(TrackingViewModel CCInfoVM, int userID)
        {
            try
            {
                CorrCompInfo corrcompinfo = new CorrCompInfo();
                corrcompinfo.cc_number = CCInfoVM.corrcmpInfo.cc_number;
                corrcompinfo.purpose_of_contact = CCInfoVM.corrcmpInfo.purpose_of_contact;
                corrcompinfo.poc_other = CCInfoVM.corrcmpInfo.poc_other;
                corrcompinfo.cc_recdin = CCInfoVM.corrcmpInfo.cc_recdin;
                corrcompinfo.date_entered = CCInfoVM.corrcmpInfo.date_entered;
                corrcompinfo.date_recd = CCInfoVM.corrcmpInfo.date_recd;
                corrcompinfo.recd_by = userID;
                corrcompinfo.cc_date = CCInfoVM.corrcmpInfo.cc_date;
                corrcompinfo.cc_status = CCInfoVM.corrcmpInfo.cc_status;
                corrcompinfo.serv_req_number = CCInfoVM.corrcmpInfo.serv_req_number;
                var result = _unitOfWork.Repository<CorrCompInfo>().ExecuteProcedure("SP_InsertUpdateTicket @cc_number,@purpose_of_contact,@poc_other,@cc_recdin,@date_recd,@recd_by,@date_entered,@cc_date,@cc_status,@serv_req_number",
                              new SqlParameter("@cc_number", SqlDbType.Int) { Value = CCInfoVM.corrcmpInfo.cc_number },
                              new SqlParameter("@purpose_of_contact", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(corrcompinfo.purpose_of_contact) ? (object)DBNull.Value : corrcompinfo.purpose_of_contact },
                              new SqlParameter("@poc_other", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(corrcompinfo.poc_other) ? (object)DBNull.Value : corrcompinfo.poc_other },
                              new SqlParameter("@cc_recdin", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(corrcompinfo.cc_recdin) ? (object)DBNull.Value : corrcompinfo.cc_recdin },
                              new SqlParameter("@date_entered", SqlDbType.Date) { Value = corrcompinfo.date_entered },
                              new SqlParameter("@date_recd", SqlDbType.Date) { Value = corrcompinfo.date_recd },
                              new SqlParameter("@recd_by", SqlDbType.Int) { Value = corrcompinfo.recd_by },
                              new SqlParameter("@cc_date", SqlDbType.DateTime) { Value = corrcompinfo.cc_date },
                              new SqlParameter("@cc_status", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(corrcompinfo.cc_status) ? (object)DBNull.Value : corrcompinfo.cc_status },
                              new SqlParameter("@serv_req_number", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(corrcompinfo.serv_req_number) ? (object)DBNull.Value : corrcompinfo.serv_req_number });
            }
            catch (Exception ex)
            {
            }
        }



        public void InsertUpdateCCCNTInfo(TrackingViewModel CCCNTInfoVM, int ccno, int UserID)
        {
            try
            {
                //// CorrCompContactInfo table
                CorrCompContactInfo corrcompCntInfo = new CorrCompContactInfo();
                corrcompCntInfo.fname = CCCNTInfoVM.corrcmpcontactInfo.fname;
                corrcompCntInfo.lname = CCCNTInfoVM.corrcmpcontactInfo.lname;
                corrcompCntInfo.tel_number = CCCNTInfoVM.corrcmpcontactInfo.tel_number;
                corrcompCntInfo.email_add = CCCNTInfoVM.corrcmpcontactInfo.email_add;
                corrcompCntInfo.street_add = CCCNTInfoVM.corrcmpcontactInfo.street_add;
                corrcompCntInfo.city = CCCNTInfoVM.corrcmpcontactInfo.city;
                corrcompCntInfo.state = CCCNTInfoVM.corrcmpcontactInfo.state;
                corrcompCntInfo.zipcode = CCCNTInfoVM.corrcmpcontactInfo.zipcode;
                corrcompCntInfo.cont_with_dfta_yn = CCCNTInfoVM.corrcmpcontactInfo.cont_with_dfta_yn;
                corrcompCntInfo.dfta_id = CCCNTInfoVM.corrcmpcontactInfo.dfta_id;
                corrcompCntInfo.other_site_name = CCCNTInfoVM.corrcmpcontactInfo.other_site_name;
                corrcompCntInfo.tstamp = DateTime.Now;
                var result1 = _unitOfWork.Repository<CorrCompInfo>().ExecuteProcedure("SP_InsertUpdateCorrCompContactInfo @cc_number,@fname,@lname,@tel_number,@email_add,@street_add,@city,@state,@zipcode,@zipcode2,@cont_with_dfta_yn,@dfta_id,@other_site_name,@last_updated_by,@tstamp",
                              new SqlParameter("@cc_number", SqlDbType.Int) { Value = CCCNTInfoVM.corrcmpInfo.cc_number },
                              new SqlParameter("@fname", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(corrcompCntInfo.fname) ? (object)DBNull.Value : corrcompCntInfo.fname },
                              new SqlParameter("@lname", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(corrcompCntInfo.lname) ? (object)DBNull.Value : corrcompCntInfo.lname },
                              new SqlParameter("@tel_number", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(corrcompCntInfo.tel_number) ? (object)DBNull.Value : corrcompCntInfo.tel_number },
                              new SqlParameter("@email_add", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(corrcompCntInfo.email_add) ? (object)DBNull.Value : corrcompCntInfo.email_add },
                              new SqlParameter("@street_add", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(corrcompCntInfo.street_add) ? (object)DBNull.Value : corrcompCntInfo.street_add },
                              new SqlParameter("@city", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(corrcompCntInfo.city) ? (object)DBNull.Value : corrcompCntInfo.city },
                              new SqlParameter("@state", SqlDbType.Char) { Value = string.IsNullOrEmpty(corrcompCntInfo.state) ? (object)DBNull.Value : corrcompCntInfo.state },
                              new SqlParameter("@zipcode", SqlDbType.Char) { Value = string.IsNullOrEmpty(corrcompCntInfo.zipcode) ? (object)DBNull.Value : corrcompCntInfo.zipcode },
                              new SqlParameter("@zipcode2", SqlDbType.Char) { Value = string.IsNullOrEmpty(corrcompCntInfo.zipcode) ? (object)DBNull.Value : corrcompCntInfo.zipcode },
                              new SqlParameter("@cont_with_dfta_yn", SqlDbType.Char) { Value = string.IsNullOrEmpty(corrcompCntInfo.cont_with_dfta_yn) ? (object)DBNull.Value : corrcompCntInfo.cont_with_dfta_yn },
                              new SqlParameter("@dfta_id", SqlDbType.Char) { Value = string.IsNullOrEmpty(corrcompCntInfo.dfta_id) ? (object)DBNull.Value : corrcompCntInfo.dfta_id },
                              new SqlParameter("@other_site_name", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(corrcompCntInfo.other_site_name) ? (object)DBNull.Value : corrcompCntInfo.other_site_name },
                              new SqlParameter("@last_updated_by", SqlDbType.Int) { Value = UserID },
                              new SqlParameter("@tstamp", SqlDbType.DateTime) { Value = corrcompCntInfo.tstamp });
            }
            catch (Exception ex)
            {
            }
        }

        public void InsertUpdateCCDetailsInfo(TrackingViewModel CCDetailsInfo, int ccno, int UserID)
        {
            try
            {
                // //IncLocationInfo table
                IncLocationInfo incLocationInfo = new IncLocationInfo();
                incLocationInfo.inc_loc_type = CCDetailsInfo.inclocationinfo.inc_loc_type;
                incLocationInfo.street_add = CCDetailsInfo.inclocationinfo.street_add;
                incLocationInfo.city = CCDetailsInfo.inclocationinfo.city;
                incLocationInfo.state = CCDetailsInfo.inclocationinfo.state;
                incLocationInfo.zipcode = CCDetailsInfo.inclocationinfo.zipcode;
                incLocationInfo.inc_loc_type = CCDetailsInfo.inclocationinfo.inc_loc_type;
                incLocationInfo.tstamp = DateTime.Now;
                var result2 = _unitOfWork.Repository<CorrCompInfo>().ExecuteProcedure("SP_InsertUpdateIncLocationInfo @cc_number,@inc_loc_type,@street_add,@city,@state,@zipcode,@zipcode2,@last_update_by,@tstamp",
                              new SqlParameter("@cc_number", SqlDbType.Int) { Value = CCDetailsInfo.corrcmpInfo.cc_number },
                              new SqlParameter("@inc_loc_type", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(incLocationInfo.inc_loc_type) ? (object)DBNull.Value : incLocationInfo.inc_loc_type },
                              new SqlParameter("@street_add", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(incLocationInfo.street_add) ? (object)DBNull.Value : incLocationInfo.street_add },
                              new SqlParameter("@city", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(incLocationInfo.city) ? (object)DBNull.Value : incLocationInfo.city },
                              new SqlParameter("@state", SqlDbType.Char) { Value = string.IsNullOrEmpty(incLocationInfo.state) ? (object)DBNull.Value : incLocationInfo.state },
                              new SqlParameter("@zipcode", SqlDbType.Char) { Value = string.IsNullOrEmpty(incLocationInfo.zipcode) ? (object)DBNull.Value : incLocationInfo.zipcode },
                              new SqlParameter("@zipcode2", SqlDbType.Char) { Value = string.IsNullOrEmpty(incLocationInfo.zipcode) ? (object)DBNull.Value : incLocationInfo.zipcode },
                              new SqlParameter("@last_update_by", SqlDbType.Int) { Value = UserID },
                              new SqlParameter("@tstamp", SqlDbType.DateTime) { Value = incLocationInfo.tstamp });
            }
            catch (Exception ex)
            {
            }
        }

        public void InsertUpdateCCReferralInfo(TrackingViewModel CCReferralInfo, int ccno, int UserID)
        {
            try
            {
                //ReferralInfo table
                ReferralInfo referralInfo = new ReferralInfo(); //@cc_number,@referred_to_group,@due_date,@referral_status,@comments,@referral_accpt_yn,@referral_rejected_comments,@last_update_by,@tstamp
                referralInfo.referred_to_group = CCReferralInfo.referralInfom.referred_to_group;
                referralInfo.due_date = DateTime.Now;
                referralInfo.referral_status = CCReferralInfo.referralInfom.referral_status;
                referralInfo.comments = CCReferralInfo.referralInfom.comments;
                referralInfo.referral_accpt_yn = CCReferralInfo.referralInfom.referral_accpt_yn;
                referralInfo.referral_rejected_comments = CCReferralInfo.referralInfom.referral_rejected_comments;
                referralInfo.last_update_by = UserID;
                referralInfo.tstamp = DateTime.Now;
                var result3 = _unitOfWork.Repository<CorrCompInfo>().ExecuteProcedure("SP_InsertUpdateReferralInfo @cc_number,@referred_to_group,@due_date,@referral_status,@comments,@referral_accpt_yn,@referral_rejected_comments,@last_update_by,@tstamp",
                              new SqlParameter("@cc_number", SqlDbType.Int) { Value = CCReferralInfo.corrcmpInfo.cc_number },
                              new SqlParameter("@referred_to_group", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(referralInfo.referred_to_group) ? (object)DBNull.Value : referralInfo.referred_to_group },
                              new SqlParameter("@due_date", SqlDbType.Date) { Value = referralInfo.due_date },
                              new SqlParameter("@referral_status", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(referralInfo.referral_status) ? (object)DBNull.Value : referralInfo.referral_status },
                              new SqlParameter("@comments", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(referralInfo.comments) ? (object)DBNull.Value : referralInfo.comments },
                              new SqlParameter("@referral_accpt_yn", SqlDbType.Char) { Value = string.IsNullOrEmpty(referralInfo.referral_accpt_yn) ? (object)DBNull.Value : referralInfo.referral_accpt_yn },
                              new SqlParameter("@referral_rejected_comments", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(referralInfo.referral_rejected_comments) ? (object)DBNull.Value : referralInfo.referral_rejected_comments },
                              new SqlParameter("@last_update_by", SqlDbType.Int) { Value = referralInfo.last_update_by },
                              new SqlParameter("@tstamp", SqlDbType.DateTime) { Value = referralInfo.tstamp });

            }
            catch (Exception ex)
            {
            }

        }
        

            public void InsertCCReferralInfo(TrackingViewModel CCReferralInfo, int ccno, int UserID)
        {
            try
            {
                //ReferralInfo table
                ReferralInfo referralInfo = new ReferralInfo(); //@cc_number,@referred_to_group,@due_date,@referral_status,@comments,@referral_accpt_yn,@referral_rejected_comments,@last_update_by,@tstamp
                referralInfo.referred_to_group = CCReferralInfo.referralInfom.referred_to_group;
                referralInfo.due_date = DateTime.Now;
                referralInfo.referral_status = CCReferralInfo.referralInfom.referral_status;
                referralInfo.comments = CCReferralInfo.referralInfom.comments;
                referralInfo.referral_accpt_yn = CCReferralInfo.referralInfom.referral_accpt_yn;
                referralInfo.referral_rejected_comments = CCReferralInfo.referralInfom.referral_rejected_comments;
                referralInfo.last_update_by = UserID;
                referralInfo.tstamp = DateTime.Now;
                var result3 = _unitOfWork.Repository<CorrCompInfo>().ExecuteProcedure("SP_InsertReferralInfo @cc_number,@referred_to_group,@due_date,@referral_status,@comments,@referral_accpt_yn,@referral_rejected_comments,@last_update_by,@tstamp",
                              new SqlParameter("@cc_number", SqlDbType.Int) { Value = CCReferralInfo.corrcmpInfo.cc_number },
                              new SqlParameter("@referred_to_group", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(referralInfo.referred_to_group) ? (object)DBNull.Value : referralInfo.referred_to_group },
                              new SqlParameter("@due_date", SqlDbType.Date) { Value = referralInfo.due_date },
                              new SqlParameter("@referral_status", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(referralInfo.referral_status) ? (object)DBNull.Value : referralInfo.referral_status },
                              new SqlParameter("@comments", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(referralInfo.comments) ? (object)DBNull.Value : referralInfo.comments },
                              new SqlParameter("@referral_accpt_yn", SqlDbType.Char) { Value = string.IsNullOrEmpty(referralInfo.referral_accpt_yn) ? (object)DBNull.Value : referralInfo.referral_accpt_yn },
                              new SqlParameter("@referral_rejected_comments", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(referralInfo.referral_rejected_comments) ? (object)DBNull.Value : referralInfo.referral_rejected_comments },
                              new SqlParameter("@last_update_by", SqlDbType.Int) { Value = referralInfo.last_update_by },
                              new SqlParameter("@tstamp", SqlDbType.DateTime) { Value = referralInfo.tstamp });

            }
            catch (Exception ex)
            {
            }

        }

        public void InsertUpdateCCResolutionInfo(TrackingViewModel CCResolutionInfo, int ccno, int UserID)
        {
            try
            {
                //Resoultion table
                ResolutionInfo resolutionInfo = new ResolutionInfo(); //@cc_number,@cc_handled_by,@resolution_status,@comments,@last_updated_by,@tstamp
                resolutionInfo.cc_handled_by = UserID;
                resolutionInfo.resolution_status = CCResolutionInfo.resolutionInfom.resolution_status;
                resolutionInfo.comments = CCResolutionInfo.resolutionInfom.comments;
                resolutionInfo.last_updated_by = UserID;
                resolutionInfo.tstamp = DateTime.Now;
                resolutionInfo.date_resolved = CCResolutionInfo.resolutionInfom.date_resolved;
                var result4 = _unitOfWork.Repository<CorrCompInfo>().ExecuteProcedure("SP_InsertUpdateResolutionInfo @cc_number,@cc_handled_by,@resolution_status,@comments,@last_updated_by,@tstamp,@date_resolved",
                             new SqlParameter("@cc_number", SqlDbType.Int) { Value = CCResolutionInfo.corrcmpInfo.cc_number },
                             new SqlParameter("@cc_handled_by", SqlDbType.Int) { Value = resolutionInfo.cc_handled_by },
                             new SqlParameter("@resolution_status", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(resolutionInfo.resolution_status) ? (object)DBNull.Value : resolutionInfo.resolution_status },
                             new SqlParameter("@comments", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(resolutionInfo.comments) ? (object)DBNull.Value : resolutionInfo.comments },
                             new SqlParameter("@last_updated_by", SqlDbType.Int) { Value = resolutionInfo.last_updated_by },
                             new SqlParameter("@tstamp", SqlDbType.DateTime) { Value = resolutionInfo.tstamp },
                             new SqlParameter("@date_resolved", SqlDbType.DateTime) { Value = resolutionInfo.tstamp });
            }
            catch (Exception ex)
            {

            }
        }

        public void InsertUpdateCorrCompDescResolution(TrackingViewModel CorrCompDescResolution, int ccno, int UserID)
        {
            try
            {
                //Description table
                CorrCompDescResolution ccDescResolution = new CorrCompDescResolution(); // @cc_number,@cc_description,@cc_description_text,@cc_resolution,@cc_resolution_text,@last_update_by,@tstamp
                ccDescResolution.cc_number = CorrCompDescResolution.corrcmpInfo.cc_number;
                if (!string.IsNullOrEmpty(CorrCompDescResolution.ccDescInfo.cc_description_text))
                {
                    // ccDescResolution.cc_description = new byte[Convert.ToInt32(CorrCompDescResolution.ccDescInfo.cc_description_text)];
                    ccDescResolution.cc_description = System.Text.ASCIIEncoding.Default.GetBytes(CorrCompDescResolution.ccDescInfo.cc_description_text);
                    ccDescResolution.cc_description_text = CorrCompDescResolution.ccDescInfo.cc_description_text;
                }
                if (!string.IsNullOrEmpty(CorrCompDescResolution.ccDescInfo.cc_resolution_text))
                {
                    // ccDescResolution.cc_resolution = new byte[Convert.ToInt32(CorrCompDescResolution.ccDescInfo.cc_resolution_text)];
                    ccDescResolution.cc_resolution = System.Text.ASCIIEncoding.Default.GetBytes(CorrCompDescResolution.ccDescInfo.cc_resolution_text);
                    ccDescResolution.cc_resolution_text = CorrCompDescResolution.ccDescInfo.cc_resolution_text;
                }
                ccDescResolution.last_update_by = UserID;
                ccDescResolution.tstamp = DateTime.Now;
                var result4 = _unitOfWork.Repository<CorrCompInfo>().ExecuteProcedure("SP_InsertUpdateCorrCompDescResolution @cc_number,@cc_description,@cc_description_text,@cc_resolution,@cc_resolution_text,@last_update_by,@tstamp",
                             new SqlParameter("@cc_number", SqlDbType.Int) { Value = ccDescResolution.cc_number.HasValue ? ccDescResolution.cc_number.Value : (object)DBNull.Value },
                             new SqlParameter("@cc_description", SqlDbType.Binary) { Value = DBNull.Value },
                             new SqlParameter("@cc_description_text", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(ccDescResolution.cc_description_text) ? (object)DBNull.Value : ccDescResolution.cc_description_text },
                             new SqlParameter("@cc_resolution", SqlDbType.Binary) { Value = DBNull.Value },
                             new SqlParameter("@cc_resolution_text", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(ccDescResolution.cc_resolution_text) ? (object)DBNull.Value : ccDescResolution.cc_resolution_text },
                             new SqlParameter("@last_update_by", SqlDbType.Int) { Value = ccDescResolution.last_update_by },
                             new SqlParameter("@tstamp", SqlDbType.DateTime) { Value = ccDescResolution.tstamp });
            }
            catch (Exception ex)
            {
            }
        }

        public void InsertUpdateDocumentsInfo(TrackingViewModel documentsVM, int ccno, int UserID)
        {
            try
            {
                //Description table
                DocumentsInfo documentsinfo = new DocumentsInfo(); // @cc_number,@attachment_type,@file_name,@file_ext,@file_location,@last_updated_by,@record_status,@tstamp
                documentsinfo.cc_number = ccno;
                documentsinfo.attachment_type = documentsVM.documentsInfom.attachment_type;
                documentsinfo.file_name = documentsVM.documentsInfom.file_name;
                documentsinfo.file_ext = documentsVM.documentsInfom.file_ext;
                documentsinfo.file_location = documentsVM.documentsInfom.file_location;
                documentsinfo.last_updated_by = UserID;
                documentsinfo.record_status = documentsVM.documentsInfom.record_status;
                documentsinfo.tstamp = DateTime.Now;
                var result4 = _unitOfWork.Repository<CorrCompInfo>().ExecuteProcedure("SP_InsertUpdateDocumentsInfo @cc_number,@attachment_type,@file_name,@file_ext,@file_location,@last_updated_by,@record_status,@tstamp",
                             new SqlParameter("@cc_number", SqlDbType.Int) { Value = documentsinfo.cc_number },
                             new SqlParameter("@attachment_type", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(documentsinfo.attachment_type) ? (object)DBNull.Value : documentsinfo.attachment_type },
                             new SqlParameter("@file_name", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(documentsinfo.file_name) ? (object)DBNull.Value : documentsinfo.file_name },
                             new SqlParameter("@file_ext", SqlDbType.Char) { Value = string.IsNullOrEmpty(documentsinfo.file_ext) ? (object)DBNull.Value : documentsinfo.file_ext },
                             new SqlParameter("@file_location", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(documentsinfo.file_location) ? (object)DBNull.Value : documentsinfo.file_location },
                             new SqlParameter("@last_updated_by", SqlDbType.Int) { Value = documentsinfo.last_updated_by },
                             new SqlParameter("@record_status", SqlDbType.VarChar) { Value = string.IsNullOrEmpty(documentsinfo.record_status) ? (object)DBNull.Value : documentsinfo.record_status },
                             new SqlParameter("@tstamp", SqlDbType.DateTime) { Value = documentsinfo.tstamp });
            }
            catch (Exception ex)
            {
            }
        }

    }
}
