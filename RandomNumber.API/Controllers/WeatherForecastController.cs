using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RandomNumber.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        //[Route("api/getSeries/{n}")]
        public async Task<IActionResult> Get(int n=15)
        {
            //Need to create series 1,1,1,3,5,9,17,31,57,105...... Sum of last 3 digits...initial 3 are fixed i.e. 1,1,1
            //need to pass Nth Number till which need to generate series
            //List<int> ar = new List<int>(); 
            
            ArrayList arr = new ArrayList();
            arr.Add(1);
            arr.Add(1);
            arr.Add(1);
            if (n > 2)
            {
                for (int i = 3; i < n; i++)
                {
                    arr.Add(Convert.ToInt32(arr[i - 3]) + Convert.ToInt32(arr[i - 2]) + Convert.ToInt32(arr[i - 1]));
                }
            }

            return Ok(  arr);
        }
    }
}
