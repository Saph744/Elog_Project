using Microsoft.Extensions.DependencyInjection;

namespace eLog.IOC
{
    public static class Dependency
    {
        private static IServiceProvider resolver;

        /// <summary>
        /// Maps TService service to its registered provider.
        /// </summary>
        /// <typeparam name="TService">Service type</typeparam>
        /// <exception cref="System.InvalidOperationException">
        /// No provider is registered for TService</exception>       
        public static TService Resolve<TService>() where TService : class
        {
            return Resolver.GetRequiredService<TService>();
        }

        /// <summary>
        /// Maps TService service to its registered provider. 
        /// Returns null if registration for TService doesn't exist or 
        /// no dependency resolver is configured using SetResolver.
        /// </summary>
        /// <typeparam name="TService">Service type</typeparam>
        public static TService TryResolve<TService>() where TService : class
        {
            return resolver == null ? null : Resolver.GetService<TService>();
        }

        /// <summary>
        /// Sets current dependency resolver and returns previous one if exists.
        /// </summary>
        /// <param name="value">Dependency resolver</param>
        public static IServiceProvider SetResolver(IServiceProvider value)
        {
            var old = resolver;
            resolver = value;
            return old;
        }

        /// <summary>
        /// Returns true if a dependency resolver is set through SetResolver.
        /// Use this property to check if there is a current resolver as Resolver 
        /// property raises an exception if not.
        /// </summary>
        public static bool HasResolver
        {
            get { return resolver != null; }
        }

        /// <summary>
        /// Returns currently registered IDependencyResolver implementation.
        /// </summary>
        /// <exception cref="System.InvalidProgramException">
        /// No dependency resolver is configured using SetResolver</exception>
        public static IServiceProvider Resolver
        {
            get
            {
                var current = resolver;

                if (current == null)
                    throw new InvalidProgramException(
                        "Default IDependencyResolver implementation is not set. Use Dependency.SetResolver " +
                        "to set your dependency resolver implementation.");

                return current;
            }
        }
    }

}
