using CTSImp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTSImp1.ViewModels;

namespace CTSImp1.Facade
{
  public  interface ISearchCTSBO
    {
        List<CorrCompInfo> GetAllTickets();
    }
}
