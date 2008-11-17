namespace MyApp.Business
{
    /// <summary>
    /// My customer DTO
    /// </summary>
    public class CustomerDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerDto"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public CustomerDto(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the int.
        /// </summary>
        /// <value>The int.</value>
        public int Int { get; set; }
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; }
        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City { get; set; }
    }
}