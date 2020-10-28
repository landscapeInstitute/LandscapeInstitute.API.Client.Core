using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace LandscapeInstitute.WebAPI.Client
{
    /// <summary>
    /// Default Authentication Filter 
    /// </summary>
    public class LandscapeServiceAuthenticationFilter : ILandscapeServiceAuthenticationFilter
    {

        public static ClientAuthenticationType AuthenticationType;
        public static string Token;

        public void Apply()
        {

            CallerBase.LandscapeService.SetAuthentication(AuthenticationType, Token);

        }

    }
}
