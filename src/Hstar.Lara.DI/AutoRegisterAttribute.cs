using Microsoft.Extensions.DependencyInjection;
using System;

namespace Hstar.Lara.DI
{
    public class AutoRegisterAttribute : Attribute
    {
        /// <summary>
        /// Mark the service for DI.
        /// </summary>
        /// <param name="serviceType">The implement class type</param>
        /// <param name="lifetime">The service lifetime</param>
        /// <param name="asSelf">Is regsister as self. Get by slef, not interface</param>
        public AutoRegisterAttribute(ServiceLifetime lifetime = ServiceLifetime.Transient, bool asSelf = false, Type serviceType = null)
        {
            Lifetime = lifetime;
            AsSelf = asSelf;
            if (serviceType != null)
            {
                this.ServiceType = serviceType;
            }
        }

        /// <summary>
        /// Service Type
        /// </summary>
        public Type ServiceType { get; set; }

        /// <summary>
        /// Lifetime
        /// </summary>
        public ServiceLifetime Lifetime { get; }

        /// <summary>
        /// Register Self
        /// </summary>
        public bool AsSelf { get; set; }
    }
}