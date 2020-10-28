using LandscapeInstitute.WebAPI.Client;
using Microsoft.Extensions.Options;
using NuGet.Frameworks;
using NUnit.Framework;
using System.Threading.Tasks;

namespace LandscapeInstitute.WebAPI.Test
{



    public class Tests
    {

        private LandscapeService landscapeService;

        [SetUp]
        public void Setup()
        {
            /* Set the Base URL For Our Unit Test */
            var settings = new LandscapeServiceOptions()
            {
                BaseUrl = "https://dev-api.landscapeinstitute.org",
            };

            /* Use our Unit Test Authentication Filter */
            settings.Authentication = new ClientAuthentication()
            {
                Type = ClientAuthenticationType.ApiKey,
                Token = "12345"
            };
                
            /* Create IOptions */
            IOptions<LandscapeServiceOptions> landscapeServiceOptions = Options.Create(settings);

            /* Create Service */
            landscapeService = new LandscapeService(landscapeServiceOptions);

        }

        [Test]
        public void GuesUnitTests()
        {

            /* Can we grab a contact */
            Assert.IsNotNull(landscapeService.Call<UnitTestingCaller>().GetContactAsync().Result, "Unable to return a contact record");

            /* Grab a GUID */
            Assert.IsNotNull(landscapeService.Call<UnitTestingCaller>().GetGuidAsync().Result, "Unable to return a GUID");

     
            Assert.Pass();

        }

        [Test]
        public void AdminUnitTests()
        {

            Assert.IsTrue(landscapeService.Call<UnitTestingCaller>().IsAdminAsync().Result);

            /* Can we grab a contact */
            Assert.IsNotNull(landscapeService.Call<UnitTestingCaller>().GetContactAsync().Result, "Unable to return a contact record");

            /* Grab a GUID */
            Assert.IsNotNull(landscapeService.Call<UnitTestingCaller>().GetGuidAsync().Result, "Unable to return a GUID");


            Assert.Pass();

        }

    }
}