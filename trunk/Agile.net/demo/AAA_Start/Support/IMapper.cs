namespace Support.Test
{
    /// <summary>
    /// Maps a type to another
    /// </summary>
    /// <typeparam name="From">The type to map from.</typeparam>
    /// <typeparam name="To">The type to map to.</typeparam>
    public interface IMapper<From, To>
    {
        /// <summary>
        /// Maps the specified from type.
        /// </summary>
        /// <param name="from">Original type to map from</param>
        /// <returns>Returns the targeted type</returns>
        To Map(From from);
    }
}