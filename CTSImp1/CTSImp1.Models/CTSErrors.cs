using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTSImp1.Models
{
    public class CTSErrors
    {
        public int error_code_id { get; set; }
        public string error_code { get; set; }
        public string stack_error_text { get; set; }
        public int last_updated_by { get; set; }
        public DateTime last_updated_date { get; set; }
        public string error_message { get; set; }
    }
}
