using LandscapeInstitute.WebAPI.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace LandscapeInstitute.WebAPI.Test
{

    public class LandscapeServiceAuthenticationFilterUnitTest : ILandscapeServiceAuthenticationFilter
    {

        private static ClientAuthenticationType clientAuthenticationType { get; set; }
        private static string authenticationToken { get; set; }

        public static void SetAuthentication(ClientAuthenticationType type, string token)
        {

            clientAuthenticationType = type;
            authenticationToken = token;
            
        }

        public void Apply()
        {

            CallerBase.LandscapeService.SetAuthentication(clientAuthenticationType, authenticationToken);

        }

    }
}
