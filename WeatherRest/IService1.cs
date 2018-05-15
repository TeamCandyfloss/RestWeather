using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
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

        /// <summary>
        /// Returns a specific temperature, containing the ID provided.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "temperatures/{id}")]
        MTemperature GetTemperature(string id);

        /// <summary>
        /// Returns the specific temperatures, containing the place. 
        /// </summary>
        /// <param name="place"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "temperatures/specifics/{place}")]
        List<MTemperature> GetSpecificTemperatures(string place);

        /// <summary>
        /// Adds a temperature with the parameters given.
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "temperatures/")]
        bool AddTemperature(MTemperature temp);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "temperatures/postTemp")]
        bool SetTemp(string temp);

        [OperationContract]
        [WebInvoke(Method = "POST",RequestFormat = WebMessageFormat.Json ,ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "temperatures/postPlace")]
        void SetPlace(string place);

        /// <summary>
        /// Delete a temperature.
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json, UriTemplate = "temperatures/")]
        bool DeleteTemperature(MTemperature temp);

        /// <summary>
        /// Updates the temperature. Only parameter available is the place.
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "temperatures/")]
        MTemperature UpdateTemperature(MTemperature temp);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "currentTemp/")]
        MTemperature GetCurrentTemperature();
    }


}
