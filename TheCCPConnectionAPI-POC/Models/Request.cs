using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheCCPConnectionAPI_POC.Models
{
    public class Request
    {
        public int RequestId { get; set; }
        public DateTime RequestTimeStamp { get; set; }
        public string RequestCourseName { get; set; }
        public float RequestCourseCreditHours { get; set; }
        public string RequestCourseTerm { get; set; }

    }
}
