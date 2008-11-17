namespace MyApp.Business
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICustomerController
    {
        /// <summary>
        /// Gets the customer.
        /// </summary>
        /// <param name="customerId">The customer id.</param>
        /// <returns></returns>
        CustomerDto GetCustomer(int customerId);

        /// <summary>
        /// Creates the customer.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        int CreateCustomer(CustomerDto dto);
    }
}