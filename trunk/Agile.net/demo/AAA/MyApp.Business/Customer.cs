namespace MyApp.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class Customer : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        public Customer(int id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public int Id { get; set; }
    }
}