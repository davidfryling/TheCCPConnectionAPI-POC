using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheCCPConnectionAPI_POC.Models;
using TheCCPConnectionAPI_POC.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheCCPConnectionAPI_POC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        //FULL VERSION TODO -- Look into versioning API endpoints

        //FULL VERSION TODO -- Look into securing API endpoints

        private IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        // GET: api/<RequestController>
        [HttpGet]
        public IEnumerable<Request> Get()
        {
            return _requestService.GetAllRequests();
        }

        //NOT IMPLEMENTED GET api/<RequestController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<RequestController>
        [HttpPost]
        public Request Post([FromBody] Request request)
        {
            if (ModelState.IsValid)
            {
                return _requestService.AddRequest(request);
            }
            return null;
        }

        //NOT IMPLEMENTED PUT api/<RequestController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //NOT IMPLEMENTED DELETE api/<RequestController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
