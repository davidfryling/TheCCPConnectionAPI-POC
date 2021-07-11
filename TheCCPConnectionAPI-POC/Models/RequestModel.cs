﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace TheCCPConnectionAPI_POC.Models
{
    public class RequestModel
    {

        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string CourseName { get; set; }
        public float CourseCreditHours { get; set; }
        public string CourseTerm { get; set; }

        //do I want this here? seems like this should be in the service...
        //public string ToJson() => JsonSerializer.Serialize<RequestModel>(this);

    }
}