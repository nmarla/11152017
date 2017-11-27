using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTSImp1.Models;

namespace CTSImp1.ViewModels
{
    public class TrackingViewModel
    {
        public CorrCompInfo corrcmpInfo { get; set; }
        public CorrCompContactInfo corrcmpcontactInfo { get; set; }
        public IncLocationInfo inclocationinfo { get; set; }
        public ReferralInfo referralInfom { get; set; }
        public ResolutionInfo resolutionInfom { get; set; }
        public DocumentsInfo documentsInfom { get; set; }
        public UserInfo userInfom { get; set; }
        public CorrCompDescResolution ccDescInfo { get; set; }
        public CorrCompDescResolution corrcompdescResolutionm { get; set; }
        public int table_no { get; set; }
        public string table_code { get; set; }
        public string short_description { get; set; }
        public string long_description { get; set; }
        public int? display_order { get; set; }
        public string visibleyn { get; set; }
        public string adm_flag { get; set; }
        public string check1_flag { get; set; }
        public string show_long_desc_info { get; set; }
        public DateTime tstamp { get; set; }
    }
}
