using MiniECommerce.Shared.Common;
using MiniECommerce.Shared.DTOs;
using System.Net.Http.Json;

namespace MiniECommerce.Blazor.WASM.Services
{
    public class CustomerService
    {
        private readonly HttpClient _httpClient;

        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PagedResult<CustomerDto>?> GetCustomersAsync(int pageNumber = 1, int pageSize = 10)
        {
            return await _httpClient.GetFromJsonAsync<PagedResult<CustomerDto>>($"api/customers?pageNumber={pageNumber}&pageSize={pageSize}");
        }

        public async Task<CustomerDto?> GetCustomerByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<CustomerDto>($"api/customers/{id}");
        }

        public async Task<CustomerDto?> CreateCustomerAsync(CreateCustomerDto customer)
        {
            var response = await _httpClient.PostAsJsonAsync("api/customers", customer);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<CustomerDto>();
            }
            return null;
        }
    }
}


