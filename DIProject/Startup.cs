// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="DiProject">
//   DI project
// </copyright>
// <summary>
//   The startup.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DIProject
{
    using DIProject.Services;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// The startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // if would be missing => Unable to resolve service for type 'DIProject.Services.IWeatherForecast' 
            services.AddTransient<IWeatherForecast, WeatherForecast>();
            services.AddControllers();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The app.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
// ako nahradit defaultny uplne ten vlastny a ako zaviest paralerne sucasne 
// .net core a fw pouzivame .net DI
// a na vsetko ostatne simpleInjector
// nesnazit sa reregistraciu -> ale zaregistrovat ho paralerne doplnim container do toho existujuceho 
// kebyze potrebujem nieco vo svojom DI tak potrebujem spravit njake proxy aby factory vratit z druheho containera 
// simple injector vlastny blog -> rozdiely inak ako .net core DI
// configuration managment - options pattern - vracia v konkretnych typoch 