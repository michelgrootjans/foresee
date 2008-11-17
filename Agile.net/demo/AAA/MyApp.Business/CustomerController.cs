using MyApp.Business.Test;
using Support.Test.Containers;

namespace MyApp.Business
{
    /// <summary>
    /// My Customer Controller
    /// </summary>
    public class CustomerController : ICustomerController
    {
        private readonly IRespository _repository;
        private readonly IValidator _validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="validator">The validator.</param>
        public CustomerController(IRespository repository, IValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        /// <summary>
        /// Gets the customer.
        /// </summary>
        /// <param name="customerId">The customer id.</param>
        /// <returns></returns>
        public CustomerDto GetCustomer(int customerId)
        {
            var customer = _repository.GetEntity<Customer>(customerId);
            var mapper = Container.GetMapper<Customer, CustomerDto>();
            return mapper.Map(customer);
        }

        /// <summary>
        /// Creates the customer.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        public int CreateCustomer(CustomerDto dto)
        {
            var mapper = Container.GetMapper<CustomerDto, Customer>();
            var customer = mapper.Map(dto);
            _validator.Validate(customer);
            _repository.Save(customer);
            return customer.Id;
        }
    }
}