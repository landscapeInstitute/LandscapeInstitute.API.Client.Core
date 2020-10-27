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

        public void Apply()
        {

            CallerBase.LandscapeService.SetAuthentication(ClientAuthenticationType.ApiKey, "12345");

        }

    }
}
