using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTSImp1.Models
{
   public class UserInfo
    {
        public int usersinfo_id { get; set; }
        public string users_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string phone_no { get; set; }
        public string user_role { get; set; }
        public string user_group { get; set; }
        public string user_status { get; set; }
        public string user_email { get; set; }
        public DateTime? last_logon_date { get; set; }
        public DateTime? tstamp { get; set; }
    }
}
