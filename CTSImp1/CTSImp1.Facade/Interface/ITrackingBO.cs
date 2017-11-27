using CTSImp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTSImp1.ViewModels;

namespace CTSImp1.Facade
{
   public interface ITrackingBO
    {
        void InsertData(TrackingViewModel corrcompinfo);
        List<CTSCodeTable> GetItemsfordropdownsctscodetable();
        int GetLastccnumber(CorrCompInfo corrcominfo);
        int GetUserIDFromUserInfo(TrackingViewModel userInfoVM);
        List<UserInfo> GetAllUserDetails(string username);
        UserInfo GetUserDetailsForID(int id);
        List<BudgetCodeModel> GetBudgetProgramType(int tableno);
        List<BudgetCodeModel> GetBudgetProgramID(string program_type);
        CorrCompInfo GetCCTKTByccno(int ccno);
        CorrCompContactInfo GetCCCNTInfo(int ccno);
        IncLocationInfo GetCCDetailsInfo(int ccno);
        ReferralInfo GetCCReferralInfo(int ccno);
        ResolutionInfo GetCCResolutionInfo(int ccno);
        DocumentsInfo GetCCAttachmentsInfo(int ccno);
        CorrCompDescResolution GetCCCommentsInfo(int ccno);
        void InsertUpdateCCInfo(TrackingViewModel CCInfoVM, int UserID);
        void InsertUpdateCCCNTInfo(TrackingViewModel CCCNTInfoVM, int ccno, int UserId);
        void InsertUpdateCCDetailsInfo(TrackingViewModel CCDetailsInfo, int ccno, int UserID);
        void InsertUpdateCCReferralInfo(TrackingViewModel CCReferralInfo, int ccno, int UserID); 
        void InsertCCReferralInfo(TrackingViewModel CCReferralInfo, int ccno, int UserID);
        void InsertUpdateCCResolutionInfo(TrackingViewModel CCResolutionInfo, int ccno, int UserID);
        void InsertUpdateCorrCompDescResolution(TrackingViewModel CorrCompDescResolution, int ccno, int UserID);
        void InsertUpdateDocumentsInfo(TrackingViewModel documentsVM, int ccno, int UserID);
    }
}
