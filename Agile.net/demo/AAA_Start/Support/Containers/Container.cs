using System;
using Support.Test;

namespace Support.Test.Containers
{
    /// <summary>
    /// Static gateway to the IoC container
    /// </summary>
    public static class Container
    {
        private static IContainer _container;

        /// <summary>
        /// Initializes the specified container.
        /// </summary>
        /// <param name="container">The container.</param>
        public static void Initialize(IContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// Gets the mapper.
        /// </summary>
        /// <typeparam name="From">Type to convert from</typeparam>
        /// <typeparam name="To">Type to convert to</typeparam>
        /// <returns>A mapper which can convert a specified type</returns>
        public static IMapper<From, To> GetMapper<From, To>()
        {
            return GetImplementationOf<IMapper<From, To>>();

        }

        /// <summary>
        /// Registers the specified implementation for a type.
        /// </summary>
        /// <typeparam name="T">Type to register an implementation for.</typeparam>
        /// <param name="implementationToRegister">The implementation to register.</param>
        public static void Register<T>(T implementationToRegister) 
        {
            if(_container == null)
            {
                throw new InvalidOperationException("The container is not initialized");
            }
            _container.Register(implementationToRegister);
        }

        /// <summary>
        /// Gets the implementation of a type.
        /// </summary>
        /// <typeparam name="T">Type to retrieve</typeparam>
        /// <returns>Implementation of a type</returns>
        public static T GetImplementationOf<T>() where T : class
        {
            try
            {
                if (_container == null)
                {
                    throw new InvalidOperationException("The container is not initialized");
                }
                return _container.GetImplementationOf<T>();
            }
            catch (Exception e)
            {
                throw new UnsatisfiedDependencyException(string.Format("Could not find an implementation for {0}", typeof(T).Name), e);
            }
        }
    }
}