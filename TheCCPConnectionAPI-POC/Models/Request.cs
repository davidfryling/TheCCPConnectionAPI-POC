using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace TheCCPConnectionAPI_POC.Models
{
    public class Request
    {
        //FULL VERSION NOTE -- Dapper maps models and tables by names, so the property and column name must be identical

        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string CourseName { get; set; }
        public float CourseCreditHours { get; set; }
        public string CourseTerm { get; set; }
        public string Message { get; set; }

        //FULL VERSION TODO -- Is there a use case for code below?
        //public string ToJson() => JsonSerializer.Serialize<RequestModel>(this);

    }
}
