using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTSImp1.Models
{
   public class CorrCompContactInfo
    {
        public int cc_contact_id { get; set; }
        public int cc_number { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string tel_number { get; set; }
        public string email_add { get; set; }
        public string street_add { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipcode { get; set; }
        public string zipcode2 { get; set; }
        public string dfta_id { get; set; }
        public string other_site_name { get; set; }
        public string last_updated_by { get; set; }
        public DateTime tstamp { get; set; }
        public string cont_with_dfta_yn { get; set; }
    }
}
