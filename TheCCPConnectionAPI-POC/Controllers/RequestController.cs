using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheCCPConnectionAPI_POC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        // build constructor to instantiate RequestService

        // build property to hold intantiated RequestService { get; } only get for now

        // build method to Get()/Post()/Put() with [HttpGet]/[HttpPost]/[HttpPut] attribute to return instantiatiated RequestService that has some sort of IEnumerable that returns serialized JSON
    }
}
