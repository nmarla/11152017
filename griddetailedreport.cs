 ////////controller action method///////////
 public ActionResult DetailReport(int ccno)
        {
            TrackingViewModel trackingVM = new TrackingViewModel();
            FillDropdowns();
            trackingVM.corrcmpInfo = _tackingBO.GetCorrcompIssuesbyccno(ccno); ;
            return View("TrackingInfo",trackingVM);
        }
		////////controller action method///////////
		///////////////tracking bo layer code///////////
		   public CorrCompInfo GetCorrcompIssuesbyccno(int ccno)
        {
            try
            {
                CorrCompInfo corrcompinfo = new CorrCompInfo();
                var result = _unitOfWork.Repository<CorrCompInfo>().ExecuteProcedureForList("SP_GetIssuesbyCCno @CCno ",
                           new SqlParameter("@CCno ", SqlDbType.VarChar) { Value = ccno }).ToList();
                corrcompinfo = result[0];
                return corrcompinfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		///////////////tracking bo layer code///////////
		////////////////itracking bo code//////////
		CorrCompInfo GetCorrcompIssuesbyccno(int ccno);
		////////////////itracking bo code//////////
		//////////////////stored proc///////////////
		USE [CTSDEV]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetIssuesbyCCno]    Script Date: 11/17/2017 20:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SP_GetIssuesbyCCno] (@CCno Int)
    As 
select * from CorrCompInfo where cc_number=@CCno

//////////////////stored proc///////////////


