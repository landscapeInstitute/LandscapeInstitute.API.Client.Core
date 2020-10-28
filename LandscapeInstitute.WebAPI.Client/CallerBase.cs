using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace LandscapeInstitute.WebAPI.Client
{


    /// <summary>
    /// Base Class for all Callers. This base class injects the current Authentication options into the webcall  
    /// </summary>
    public class CallerBase
    {

        public static ILandscapeService LandscapeService;
        public static IOptions<LandscapeServiceOptions> LandscapeServiceOptions;

        private string _baseUrl;

        public CallerBase()
        {
  
        }

        public string BaseUrl
        {
            get { return _baseUrl; }
            set { _baseUrl = value; }
        }

        /* Called by implementing Swagger Client Caller Classes */
        protected async Task<HttpRequestMessage> CreateHttpRequestMessageAsync(CancellationToken cancellationToken)
        {
            var msg = new HttpRequestMessage();

            if (LandscapeService.GetAuthentication() != null)
            {

                if(LandscapeService.GetAuthentication().Type == ClientAuthenticationType.AccessToken)
                {
                    msg.Headers.Add("bearer", LandscapeService.GetAuthentication().Token);
                }

                if (LandscapeService.GetAuthentication().Type == ClientAuthenticationType.ApiKey)
                {
                    msg.Headers.Add("x-api-key", LandscapeService.GetAuthentication().Token);
                }

            }

            return msg;
        }

    }

}
