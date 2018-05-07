using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using WeatherRest.model;

namespace WeatherRest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        private string _connectionString = "Server=tcp:3semesterxxx.database.windows.net,1433;Initial Catalog=WCFSTUDENT;Persist Security Info=False;User ID={Admeme};Password={Skole123};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        
        
        public List<Temperature> GetAllTemperatures()
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var temperatureList = connection.GetAll<Temperature>().ToList();

                return temperatureList;
            }

        }
    }
}
