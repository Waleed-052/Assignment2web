using Assignment2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2.Data
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray());
        }
        [HttpGet("GetName/{FirstName}/{LastName}")]
        public string GetName(string FirstName, string LastName)
        {
            return "Hi i am " + FirstName + " Father Name is " + LastName;
        }

        [HttpPost("SaveName/{First}/{LastName}")]
        public string SaveName(string FirstName, string LastName)
        {
            return "Hi i am " + FirstName + " And My Father Name is " + LastName;
        }

        [HttpPost("SaveStudent")]
        public string SaveStudent(Employee Employeed)
        {

            return "Hi i am " + Employeed.FirstName + " My Father Name is " + Employeed.LastName;
        }
    }
}
