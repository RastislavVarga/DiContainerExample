// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWeatherForecast.cs" company="DI project">
//   DI project
// </copyright>
// <summary>
//   The WeatherForecast interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DIProject.Services
{
    using System;

    using DIProject.Contract;

    /// <summary>
    /// The WeatherForecast interface.
    /// </summary>
    public interface IWeatherForecast
    {
        /// <summary>
        /// The get weather forecast.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The <see cref="ForecastInfoDto"/>.</returns>
        ForecastInfoDto GetWeatherForecast(DateTime date);
    }
}