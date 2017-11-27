using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTSImp1.Models;
using System.Data.SqlClient;
using System.Data;
using CTSImp1.DataLayer;

namespace CTSImp1.Facade
{
    public class ExceptionsBO : IExceptionsBO
    {
        #region "Unitofwork Reference"
        IUnitOfWork _unitOfWork = null;

        public ExceptionsBO(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }
        public ExceptionsBO()
        {
            _unitOfWork = new UnitOfWork();
        }

        #endregion

        public void SaveLogData(Exception exmsg)
        {
            try
            {
                var result = _unitOfWork.Repository<CTSErrors>().ExecuteProcedure("SP_InsertCTSErrors @error_code,@stack_error_text,@last_updated_by,@last_updated_date,@error_message",
                             new SqlParameter("@error_code", SqlDbType.VarChar) { Value = exmsg.HResult },
                             new SqlParameter("@stack_error_text", SqlDbType.Text) { Value = exmsg.StackTrace },
                             new SqlParameter("@last_updated_by", SqlDbType.Int) { Value = 1 },
                             new SqlParameter("@last_updated_date", SqlDbType.DateTime) { Value = DateTime.Now },
                             new SqlParameter("@error_message", SqlDbType.VarChar) { Value = exmsg.Message });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
