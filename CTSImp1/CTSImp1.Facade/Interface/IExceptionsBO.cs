using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTSImp1.Facade
{
    public interface IExceptionsBO
    {
        void SaveLogData(Exception ex);
    }
}
