// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeatherForecastController.cs" company="DI Project">
//   DI project
// </copyright>
// <summary>
//   Defines the WeatherForecastController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DIProject.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DIProject.Contract;
    using DIProject.Services;

    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The weather forecast controller.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        /// <summary>
        /// The weather forecast.
        /// </summary>
        private readonly IWeatherForecast weatherForecast;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherForecastController"/> class.
        /// </summary>
        /// <param name="weatherForecast">The weather Forecast.</param>
        public WeatherForecastController(IWeatherForecast weatherForecast)
        {
            this.weatherForecast = weatherForecast;
        }

        /// <summary>
        /// The get weather forecasts..
        /// </summary>
        /// <returns>The List of weather forecasts.</returns>
        [HttpGet]
        public IEnumerable<ForecastInfoDto> GetWeatherForecasts()
        {
            var rng = new Random();
            
            return Enumerable.Range(1, 5).Select(index =>
                    {
                        // 1. instance creation
                        // var forecast = new WeatherForecast();
                        // var date = DateTime.Now.AddDays(index);
                        // return forecast.GetWeatherForecast(date);
                        // 
                        // 2. used injected IWeather service
                        var date = DateTime.Now.AddDays(index);
                        return this.weatherForecast.GetWeatherForecast(date);
                    })
            .ToArray();
        }
    }
}
