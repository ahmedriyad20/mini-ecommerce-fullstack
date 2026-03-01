
using MiniECommerce.Domain.Entities;
using MiniECommerce.Infrastructure.Repositories;
using MiniECommerce.Service.Interfaces;
using MiniECommerce.Shared.Common;
using MiniECommerce.Shared.DTOs;

namespace MiniECommerce.Service.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        //public async Task<Result<CustomerDto>> CreateCustomer(CustomerDto customer)
        //{
        //    var customerEntity = new Customer
        //    {
        //        Id = Guid.NewGuid(),
        //        FullName = customer.FullName,
        //        Phone = customer.Phone,
        //    };

        //    await _customerRepository.AddAsync(customerEntity);
        //    return Result<CustomerDto>.Success(customer);
        //}

        public async Task<Customer> CreateCustomer(Customer newCustomer)
        {
            return await _customerRepository.AddAsync(newCustomer);
        }

        public IQueryable<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAll();
        }
    }
}
