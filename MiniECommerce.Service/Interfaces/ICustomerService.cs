

using MiniECommerce.Domain.Entities;
using MiniECommerce.Shared.Common;
using MiniECommerce.Shared.DTOs;

namespace MiniECommerce.Service.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomer(Customer newCustomer);
        IQueryable<Customer> GetAllCustomers();
    }
}
