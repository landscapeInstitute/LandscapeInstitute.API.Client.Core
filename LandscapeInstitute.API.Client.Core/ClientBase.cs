using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace LandscapeInstitute.WebAPI.Client
{

    public enum ClientAuthenticationType
    {
        AccessToken = 1,
        ApiKey = 2

    }

    public class ClientAuthentication
    {

        public ClientAuthenticationType Type;
        public string Token;

    }

    static class ClientBaseAuthentication
    {
        public static ClientAuthentication authentication;
    }

    /* Base Class that all Callers Extend, Injects Into a user token when one is found against the caller user */
    internal abstract class ClientBase
    {
        /* Called by implementing Swagger Client Caller Classes */
        protected async Task<HttpRequestMessage> CreateHttpRequestMessageAsync(CancellationToken cancellationToken)
        {
            var msg = new HttpRequestMessage();

            if(ClientBaseAuthentication.authentication != null)
            {

                if(ClientBaseAuthentication.authentication.Type == ClientAuthenticationType.AccessToken)
                {
                    msg.Headers.Add("bearer", ClientBaseAuthentication.authentication.Token);
                }

                if (ClientBaseAuthentication.authentication.Type == ClientAuthenticationType.ApiKey)
                {
                    msg.Headers.Add("x-api-key", ClientBaseAuthentication.authentication.Token);
                }

            }

            return msg;
        }

    }

}
