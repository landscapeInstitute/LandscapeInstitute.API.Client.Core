using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace LandscapeInstitute.WebAPI.Client
{

    /// <summary>
    /// Landscape Service Interface
    /// </summary>
    public interface ILandscapeService
    {
        public T Call<T>(string baseUrl = null);
        public void SetAuthentication(ClientAuthenticationType type, string token);
        public ClientAuthentication GetAuthentication();
    }

    /// <summary>
    /// Landscape Service Class, This is the class setup for DI and used to call the API. 
    /// </summary>
    public class LandscapeService : ILandscapeService
    {

        private string _baseUrl;
        private Type _authenticationFilterType;
        private ClientAuthentication _authentication;

        public LandscapeService(IOptions<LandscapeServiceOptions> options)
        {
            _baseUrl = options.Value.BaseUrl;
            _authenticationFilterType = options.Value.AuthenticationFilterType;

            CallerBase.LandscapeService = this;
            CallerBase.LandscapeServiceOptions = options;
            Activator.CreateInstance(_authenticationFilterType);

        }

        /// <summary>
        /// Call an API Caller
        /// </summary>
        public T Call<T>(string baseUrl = null)
        {

            object authenticationFilter = Activator.CreateInstance(_authenticationFilterType);
            MethodInfo method = _authenticationFilterType.GetMethod("Apply", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            method.Invoke(authenticationFilter, null);

            return (T)Activator.CreateInstance(typeof(T), args: _baseUrl);
        }

        /// <summary>
        /// Set the Authentication Method
        /// </summary>
        public void SetAuthentication(ClientAuthenticationType type, string token)
        {

            _authentication = new ClientAuthentication()
            {
                Type = type,
                Token = token
            };

        }

        /// <summary>
        /// Get the Authentication Method
        /// </summary>
        public ClientAuthentication GetAuthentication()
        {

            return _authentication;

        }

    }

    /// <summary>
    /// Options usued to setup a Landscape Service
    /// </summary>
    public class LandscapeServiceOptions
    {
        /// <summary>
        /// The API Base URL including protocol. 
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// Authentication Filter, must be a class derived from ILandscapeServiceAuthenticationFilter with an Apply Void which calls CallerBase.LandscapeService.SetAuthentication
        /// </summary>
        public void AuthenticationFilter<TFilter>(params object[] arguments) where TFilter : ILandscapeServiceAuthenticationFilter
        {
            AuthenticationFilterType = typeof(TFilter);
        }

        public Type AuthenticationFilterType { get; set; }
    }

    /// <summary>
    /// Generic Filter Interface
    /// </summary>
    public interface ILandscapeServiceFilter
    {
        void Apply();
    }

    /// <summary>
    /// Generic Authentication Filter Interface
    /// </summary>
    public interface ILandscapeServiceAuthenticationFilter : ILandscapeServiceFilter
    {
        new void Apply();

    }



}
