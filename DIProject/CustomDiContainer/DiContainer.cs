namespace TryingStuffOut.DependencyInjection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The di container.
    /// </summary>
    public class DiContainer
    {
        private readonly Dictionary<Type, ServiceDescriptor> serviceDescriptors;

        public DiContainer(Dictionary<Type, ServiceDescriptor> serviceDescriptors)
        {
            this.serviceDescriptors = serviceDescriptors;
        }

        public object GetService(Type serviceType)
        {
            var descriptor = this.serviceDescriptors[serviceType];

            if (descriptor == null)
            {
                throw new Exception($"Service of type {serviceType.Name} isn't registered");
            }
            
            if (descriptor.Implementation != null)
            {
                return descriptor.Implementation;
            }

            var actualType = descriptor.ImplementationType ?? descriptor.ServiceType;

            if (actualType.IsAbstract || actualType.IsInterface)
            {
                throw new Exception("cannot instantiate abstact classes or interfaces");
            }

            var constructorInfo = actualType.GetConstructors().First();

            var parameters = constructorInfo
                .GetParameters()
                .Select(x => GetService(x.ParameterType))
                .ToArray();

            var implementation = Activator
                .CreateInstance(actualType, parameters);

            if (descriptor.Lifetime == ServiceLifetime.Singleton)
            {
                descriptor.Implementation = implementation;
            }
            
            return implementation;
        }

        public T GetService<T>()
        {
            return (T)this.GetService(typeof(T));
        }
    }
}