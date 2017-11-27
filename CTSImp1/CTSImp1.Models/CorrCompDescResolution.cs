using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CTSImp1.Models
{
   public class CorrCompDescResolution
    {
        public int cc_desc_id { get; set; }
        public int? cc_number { get; set; }
        public Byte[] cc_description { get; set; }
        [AllowHtml]
        public string cc_description_text { get; set; }
        public Byte[] cc_resolution { get; set; }
        [AllowHtml]
        public string cc_resolution_text { get; set; }
        public int last_update_by { get; set; }
        public DateTime tstamp { get; set; }
    }
}
