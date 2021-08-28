using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TodoApiWithTrace.Controllers
{
    public class MyController : ControllerBase
    {
        private static readonly ActivitySource Activity = new(nameof(MyController));
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public MyController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<string> RandomUser()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://randomuser.me/api/");
            var responseStr = await response.Content.ReadAsStringAsync();
            return responseStr;
        }

        public async Task<string> DetailedTrace()
        {
            using (var ac = Activity.StartActivity("UsingService"))
            {
                _logger.LogWarning("Service Executed Here");
                using (var ac2 = Activity.StartActivity("UsingRepository"))
                {
                    _logger.LogWarning("Repositry Executed here");
                }
            }
            return "Hello tracing!";
        }
    }
}
