using System.Collections.Generic;
using TheCCPConnectionAPI_POC.Models;

namespace TheCCPConnectionAPI_POC.Services
{
    public interface IRequestService
    {
        Request AddRequest(Request request);
        List<Request> GetAllRequests();
    }
}