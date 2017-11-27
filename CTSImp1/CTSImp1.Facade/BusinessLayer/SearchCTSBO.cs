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
  public  class SearchCTSBO : ISearchCTSBO
    {
        #region "Unitofwork Reference"
        IUnitOfWork _unitOfWork = null;

        public SearchCTSBO(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }
        public SearchCTSBO()
        {
            _unitOfWork = new UnitOfWork();
        }

        #endregion
        public List<CorrCompInfo> GetAllTickets()
        {
            try
            {
                var result = _unitOfWork.Repository<CorrCompInfo>().ExecuteProcedureForList("SP_GETALLTicket").ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

    }
}
