using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTSImp1.Models
{
  public  class ResolutionInfo
    {
        public int resolution_id { get; set; }
        public int? cc_number { get; set; }
        public int cc_handled_by { get; set; }
        public string comments { get; set; }
        public int last_updated_by { get; set; }
        public DateTime tstamp { get; set; }
        public string resolution_status { get; set; }
        public DateTime date_resolved { get; set; }
    }
}
