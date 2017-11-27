using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTSImp1.Models
{
  public  class DocumentsInfo
    {
        public int attachment_id { get; set; }
        public int cc_number { get; set; }
        public string attachment_type { get; set; }
        public string file_name { get; set; }
        public string file_ext { get; set; }
        public string file_location { get; set; }
        public int last_updated_by { get; set; }
        public string record_status { get; set; }
        public DateTime tstamp { get; set; }
    }
}
