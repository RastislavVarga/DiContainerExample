// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeatherForecast.cs" company="DI project">
//   DI project
// </copyright>
// <summary>
//   Defines the WeatherForecast type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DIProject.Services
{
    using System;
    using System.ComponentModel;

    using DIProject.Contract;

    /// <summary>
    /// The weather forecast.
    /// </summary>
    public class WeatherForecast : IWeatherForecast
    {
        /// <summary>
        /// The summaries.
        /// </summary>
        private static readonly string[] Summaries = new[]
                                                         {
                                                             "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
                                                         };
        
        /// <inheritdoc/>
        public ForecastInfoDto GetWeatherForecast(DateTime date)
        {
            var rng = new Random();

            var data = new ForecastInfoDto()
                           {
                               Date = date,
                               TemperatureC = rng.Next(-20, 55),
                               Summary = Summaries[rng.Next(Summaries.Length)]
                           };

            return data;
        }
    }
}
