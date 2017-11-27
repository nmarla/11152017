using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTSImp1.Models
{
   public class CorrCompInfo
    {
        public int cc_number { get; set; }
        public string purpose_of_contact { get; set; }
        public string poc_other { get; set; }
        public string cc_recdin { get; set; }
        public DateTime date_recd { get; set; }
        public int recd_by { get; set; }
        public DateTime date_entered { get; set; }
        public DateTime cc_date { get; set; }
        public string cc_status { get; set; }
        public string serv_req_number { get; set; }
    }
}
