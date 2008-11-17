namespace Support.Test
{
    ///<summary>
    ///</summary>
    public interface IContainer
    {
        /// <summary>
        /// Registers the specified implementation for a type.
        /// </summary>
        /// <typeparam name="T">Type to register an implementation for.</typeparam>
        /// <param name="implementationToRegister">The implementation to register.</param>
        void Register<T>(T implementationToRegister);

        /// <summary>
        /// Gets the implementation of a type.
        /// </summary>
        /// <typeparam name="T">Type to retrieve</typeparam>
        /// <returns>Implementation of a type</returns>
        T GetImplementationOf<T>() where T : class;
    }
}