using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheCCPConnectionAPI_POC.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using TheCCPConnectionAPI_POC.Common;
using TheCCPConnectionAPI_POC.IServices;

namespace TheCCPConnectionAPI_POC.Services
{
    public class RequestService : IRequestService
    {
        //FULL VERSON TODO -- Take time to map this pattern onto all dB objects and models so that it goes smoothly at full scale

        Request _oRequest = new Request();
        List<Request> _oRequests = new List<Request>();

        //FULL VERSION TODO -- create parament to that the requests pulled are only for the user type
        //Example, student gets all of THEIR request for term selected, while parent for all of their students
        //and counselors/advisors for all of the students in their high school
        public List<Request> GetAllRequests()
        {
            _oRequests = new List<Request>();

            using (IDbConnection connection = new SqlConnection(Global.ConnectionString))
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                var oRequests = connection.Query<Request>("dbo.GetAllRequestsStoredProcedure").ToList();
                
                if (oRequests != null && oRequests.Count() > 0)
                {
                    _oRequests = oRequests;
                }
            }

            return _oRequests;
        }

        public Request AddRequest(Request request)
        {
            _oRequest = new Request();

            try
            {
                using (IDbConnection connection = new SqlConnection(Global.ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed) connection.Open();

                    var oRequests = connection.Query<Request>("dbo.InsertNewRequestStoredProcedure", this.SetParameters(request), commandType: CommandType.StoredProcedure);
                    
                    if (oRequests != null && oRequests.Count() > 0)
                    {
                        _oRequest = oRequests.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oRequest.Message = ex.Message;
            }

            return _oRequest;
        }

        private DynamicParameters SetParameters(Request request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", request.Id);
            parameters.Add("@Timestamp", request.Timestamp);
            parameters.Add("@CourseName", request.CourseName);
            parameters.Add("@CourseCreditHours", request.CourseCreditHours);
            parameters.Add("@CourseTerm", request.CourseTerm);

            return parameters;
        }
    }
}
