using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WeatherRest.model;

namespace WeatherRest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        /// <summary>
        /// GetAllTemperatures returns all entries from the table.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "temperatures/")]
        List<MTemperature> GetAllTemperatures();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "temperatures/{id}")]
        MTemperature GetTemperature(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "temperatures/specifics/{place}")]
        List<MTemperature> GetSpecificTemperatures(string place);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "temperatures/")]
        bool AddTemperature(MTemperature temp);

        [OperationContract]
        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json, UriTemplate = "temperatures/")]
        bool DeleteTemperature(MTemperature temp);

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "temperatures/")]
        MTemperature UpdateTemperature(MTemperature temp);

    }


}
