using System.Collections.Generic;
using TheCCPConnectionAPI_POC.Models;

namespace TheCCPConnectionAPI_POC.IServices
{
    public interface IRequestService
    {
        //FULL VERSION OPTION -- Could start with all of these and extract other classes from Interface, instead of the other way around
        //Which might be easier to create, since all of this should be mapped out ahead of time

        Request AddRequest(Request request);
        List<Request> GetAllRequests();
    }
}