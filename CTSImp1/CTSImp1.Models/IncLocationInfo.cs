using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTSImp1.Models
{
   public class IncLocationInfo
    {
        public int inc_loc_id { get; set; }
        public int cc_number { get; set; }
        public string inc_loc_type { get; set; }
        public string street_add { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipcode { get; set; }
        public string zipcode2 { get; set; }
        public int last_update_by { get; set; }
        public DateTime tstamp { get; set; }
    }
}
