using System;
using System.Collections.Generic;
using System.Text;

namespace LandscapeInstitute.WebAPI.Client
{

    /// <summary>
    /// Defined Authentication Types, Either Using an AccessToken provided by an Identity Server or an API Key
    /// </summary>
    public enum ClientAuthenticationType
    {
        AccessToken = 1,
        ApiKey = 2,
        Guest = 3

    }

    /// <summary>
    /// Holder class for the Token and Type
    /// </summary>
    public class ClientAuthentication
    {

        public ClientAuthenticationType Type;
        public string Token;

    }

}
