

namespace TryingStuffOut.DependencyInjection
{
    using System.Collections.Generic;
    using System;

    public class DiServiceCollection
    {
        private Dictionary<Type, ServiceDescriptor> _serviceDescriptors = new Dictionary<Type, ServiceDescriptor>(); 
        
        public void RegisterSingleton<TService>(TService implementation)
        {
            _serviceDescriptors.Add(typeof(TService), new ServiceDescriptor(implementation, ServiceLifetime.Singleton));
        }

        public void RegisterSingleton<TService>()
        {
            _serviceDescriptors.Add(typeof(TService), new ServiceDescriptor(typeof(TService), ServiceLifetime.Singleton));
        }

        public void RegisterSingleton<TService, TImplementation>() where TImplementation : TService
        {
            _serviceDescriptors.Add(typeof(TService), new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Singleton));
        }

        public void RegisterTransient<TService>()
        {
            _serviceDescriptors.Add(typeof(TService), new ServiceDescriptor(typeof(TService), ServiceLifetime.Transient));
        }

        public void RegisterTransient<TService, TImplementation>() where TImplementation : TService
        {
            _serviceDescriptors.Add(typeof(TService), new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Transient));
        }
        
        public DiContainer CreateContainer()
        {
            return new DiContainer(_serviceDescriptors);
        }
    }
}