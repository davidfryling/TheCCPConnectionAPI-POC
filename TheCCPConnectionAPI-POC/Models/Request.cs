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
        public DateTime Timestamp { get; set; }
        public string CourseName { get; set; }
        public float CourseCreditHours { get; set; }
        public string CourseTerm { get; set; }

        //TODO REMOVE --do I want this here? seems like this should be in the service... -- user Utf8JsonWriter??
        //public string ToJson() => JsonSerializer.Serialize<RequestModel>(this);

    }
}
