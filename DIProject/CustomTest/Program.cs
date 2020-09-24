using System;
using System.Threading.Tasks;
using TryingStuffOut.DependencyInjection;

namespace TryingStuffOut
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = new DiServiceCollection();

            //services.RegisterSingleton(new RandomGuidGenerator());
            //services.RegisterSingleton<RandomGuidGenerator>();
            //services.RegisterTransient<RandomGuidGenerator>();

            
            services.RegisterSingleton<IRandomGuidProvider, RandomGuidProvider>();
            services.RegisterTransient<ISomeService, SomeService>();
            var container = services.CreateContainer();

            var serviceFirst = container.GetService<ISomeService>();
            var serviceSecond = container.GetService<ISomeService>();

            serviceFirst.PrintSomething();
            serviceSecond.PrintSomething();
        }
    }
}