using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace LandscapeInstitute.WebAPI.Client
{

    /// <summary>
    /// The APIException Class is a custom exception class for the API. The API Returns a JSON Object this this class uses 
    /// </summary>
    public partial class APIException : System.Exception
    {
        public int StatusCode { get; private set; }

        public string Response { get; private set; }

        public override string Message
        {
            get
            {
                return Regex.Match(base.Message, @"\:""([^)]*)\""").Groups[1].Value;
            }
        }

        public System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> Headers { get; private set; }

        public APIException(string message, int statusCode, string response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Exception innerException)
            : base(message + "\n\nStatus: " + statusCode + "\nResponse: \n" + response.Substring(0, response.Length >= 512 ? 512 : response.Length), innerException)
        {

            StatusCode = statusCode;
            Response = response;
            Headers = headers;
        }

        public override string ToString()
        {
            return string.Format("HTTP Responseseses: \n\n{0}\n\n{1}", Response, base.ToString());
        }

        public string ErrorResponse()
        {

            var jsonResponse = JsonConvert.DeserializeObject<Dictionary<string, string>>(Response);

            if (jsonResponse.ContainsKey("error"))
            {
                return jsonResponse["error"];
            }
            else
            {
                return "Something went wrong...";
            }


        }

    }
}
