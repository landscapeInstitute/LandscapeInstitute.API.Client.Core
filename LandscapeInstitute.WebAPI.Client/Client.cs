using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandscapeInstitute.WebAPI.Client
{
    public class Client
    {


        private string BaseUrl;


        public Client(string baseUrl, ClientAuthentication authentication)
        {
            BaseUrl = baseUrl;
            ClientBaseAuthentication.authentication = authentication;
        }

        public T Call<T>(string baseUrl = null)
        {

            return (T)Activator.CreateInstance(typeof(T), args: BaseUrl);

        }

    }
}
