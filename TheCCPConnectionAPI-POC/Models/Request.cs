using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace TheCCPConnectionAPI_POC.Models
{
    public class Request
    {

        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string CourseName { get; set; }
        public float CourseCreditHours { get; set; }
        public string CourseTerm { get; set; }

        public string ToJson() => JsonSerializer.Serialize<Request>(this);

    }
}
