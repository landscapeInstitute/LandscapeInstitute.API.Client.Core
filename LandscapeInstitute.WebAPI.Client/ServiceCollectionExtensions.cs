using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace LandscapeInstitute.WebAPI.Client
{
    /// <summary>
    /// Landscape Service Service Collection Extension
    /// </summary>
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddLandscapeService(this IServiceCollection services, Action<LandscapeServiceOptions> setup)
        {

            /* Inject the Landscape Service Options and a Transient Instance of the Service */
            services.Configure(setup);
            services.AddTransient<ILandscapeService, LandscapeService>();

            return services;
        }

    }
}
