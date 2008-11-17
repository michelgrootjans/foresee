using System;
using Artilium.Arta.Test.AAA;
using Rhino.Mocks;
using NUnit.Framework;
using Support.Test;

namespace MyApp.Business.Test
{
    public class When_CustomerController_gets_a_customer : ArrangeActAssert<ICustomerController>
    {
        private IRespository repository;
        private const int customerId = 12345;
        private IMapper<Customer, CustomerDto> mapper;
        private Customer customer;
        private IValidator validator;

        public override void Arrange()
        {
            repository = Dependency<IRespository>();
            validator = Dependency<IValidator>();
            mapper = DependencyInContainer<IMapper<Customer, CustomerDto>>();
            customer = new Customer(customerId);
            repository.Stub(r => r.GetEntity<Customer>(customerId)).Return(customer);
        }

        public override ICustomerController CreateSUT()
        {
            return new CustomerController(repository, validator);
        }

        public override void Act()
        {
            sut.GetCustomer(customerId);
        }

        [Test]
        public void should_get_the_customer_from_the_repository()
        {
            repository.AssertWasCalled(r => r.GetEntity<Customer>(customerId));
        }

        [Test]
        public void should_map_the_customer_to_the_customer_dto()
        {
            mapper.AssertWasCalled(m => m.Map(customer));
        }


    }

    public class When_CustomerController_create_a_customer : ArrangeActAssert<ICustomerController>
    {
        private IRespository repository;
        private IMapper<CustomerDto, Customer> mapper;
        private CustomerDto customerDto;
        private const int customerId = 12345;
        private Customer customer;
        private int result;
        private IValidator validator;

        public override void Arrange()
        {
            customerDto = new CustomerDto("peter");
            customer = new Customer(customerId);
            repository = Dependency<IRespository>();
            validator = Dependency<IValidator>();
            mapper = DependencyInContainer<IMapper<CustomerDto, Customer>>();
            mapper.Stub(m => m.Map(customerDto)).Return(customer);
        }

        public override ICustomerController CreateSUT()
        {
            return new CustomerController(repository, validator);
        }

        public override void Act()
        {
            result = sut.CreateCustomer(customerDto);
        }

        [Test]
        public void should_save_the_entity_to_the_respository()
        {
            repository.AssertWasCalled(r => r.Save(customer));
        }

        [Test]
        public void should_map_the_customerDto_to_the_entity()
        {
            mapper.AssertWasCalled(m => m.Map(customerDto));
        }

        [Test]
        public void should_return_the_customerId()
        {
            result.ShouldBeEqualTo(customerId);
        }

        [Test]
        public void should_validate_the_customer()
        {
            validator.AssertWasCalled(v => v.Validate(customer));
        }
    }
}