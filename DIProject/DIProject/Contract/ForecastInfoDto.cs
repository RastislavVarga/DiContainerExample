// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ForecastInfoDto.cs" company="DI project">
//   DI project
// </copyright>
// <summary>
//   Defines the ForecastInfoDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DIProject.Contract
{
    using System;

    /// <summary>
    /// The forecast info.
    /// </summary>
    public class ForecastInfoDto
    {
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the temperature c.
        /// </summary>
        public int TemperatureC { get; set; }

        /// <summary>
        /// The temperature f.
        /// </summary>
        public int TemperatureF => 32 + (int)(this.TemperatureC / 0.5556);

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        public string Summary { get; set; }
    }
}
