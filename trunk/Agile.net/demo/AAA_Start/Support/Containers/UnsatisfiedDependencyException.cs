using System;

namespace Support.Test.Containers
{
    /// <summary>
    /// Arta exception
    /// </summary>
    public class UnsatisfiedDependencyException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnsatisfiedDependencyException"/> class.
        /// </summary>
        public UnsatisfiedDependencyException() {}

        /// <summary>
        /// Initializes a new instance of the <see cref="UnsatisfiedDependencyException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public UnsatisfiedDependencyException(string message) : base(message) {}

        /// <summary>
        /// Initializes a new instance of the <see cref="UnsatisfiedDependencyException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public UnsatisfiedDependencyException(string message, Exception innerException) : base(message, innerException) { }
    }
}