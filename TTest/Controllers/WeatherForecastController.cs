using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TTest.Models.Test;

namespace TTest.Controllers
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
        private readonly TestContext test;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, TestContext test)
        {
            _logger = logger;
            this.test = test;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("Heart")]
        public dynamic function()
        {
            Heart hhhh = test.Heart.Find((uint)1);
            hhhh.Heart1++;
            test.SaveChanges();
            return null;// hhhh.Heart1;
        }

        [HttpGet("get_heart")]
        public dynamic ffff()
        {
            Heart hhhh = test.Heart.Find((uint)1);
            return hhhh.Heart1;
        }

        [HttpGet("get_liuyan")]
        public dynamic functiongetliuyan()
        {
            System.Linq.IQueryable<LiuYan> ly = test.LiuYan.OrderByDescending(c => c.Id).Take(10);
            return ly;
        }

        [HttpPost("liuyan")]
        public dynamic functionpost(LiuYan liuyan)
        {
            // string ipaddress = context.HttpContext.Connection.RemoteIpAddress.ToString();
            test.LiuYan.Add(liuyan);
            test.SaveChanges();
            return Ok();
        }
    }
}
