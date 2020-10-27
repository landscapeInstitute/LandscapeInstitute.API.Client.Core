using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LandscapeInstitute.WebAPI.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace LandscapeInstitute.WebAPI.Client.Example.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILandscapeService _landscapeService;

        public HomeController(ILandscapeService landscapeService)
        {
            _landscapeService = landscapeService;
        }

        public async Task<IActionResult> Index()
        {
            var contact = await _landscapeService.Call<UnitTestingCaller>().GetContactAsync();

            return View();
        }

    }
}
