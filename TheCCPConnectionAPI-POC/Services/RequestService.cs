using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheCCPConnectionAPI_POC.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using TheCCPConnectionAPI_POC.Common;

namespace TheCCPConnectionAPI_POC.Services
{
    public class RequestService : IRequestService
    {

        //Services are simply encapsulated classes that get data from the dB and turn it into the C# object 
        
        public List<Request> GetAllRequests()
        {
            using (IDbConnection connection = new SqlConnection(Global.ConnectionString))
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                return connection.Query<Request>("EXEC GetAllRequestsStoredProcedure").ToList();
            }
        }

        public Request AddRequest(Request request)
        {
            using (IDbConnection connection = new SqlConnection(Global.ConnectionString))
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                string sql = "EXEC InsertNewRequestStoredProcedure";

                connection.Execute(sql, this.SetParameters(request), commandType: CommandType.StoredProcedure);

                return request;
            }
        }

        private DynamicParameters SetParameters(Request request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@requestTimestamp", request.Id);
            parameters.Add("@requestCourseName", request.CourseName);
            parameters.Add("@requestCourseCreditHours", request.CourseCreditHours);
            parameters.Add("@requestCourseTerm)", request.CourseTerm);

            return parameters;
        }
    }
}
