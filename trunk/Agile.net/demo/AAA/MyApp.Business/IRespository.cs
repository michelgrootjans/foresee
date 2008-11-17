namespace MyApp.Business
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRespository
    {
        /// <summary>
        /// Gets the entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        T GetEntity<T>(int id) where T : IEntity;

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The customer.</param>
        void Save(IEntity entity);
    }
}