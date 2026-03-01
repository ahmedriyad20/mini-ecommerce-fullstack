using MiniECommerce.Shared.Common;
using MiniECommerce.Shared.DTOs;
using System.Net.Http.Json;

namespace MiniECommerce.Blazor.WASM.Services
{
    public class OrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PagedResult<OrderDto>?> GetOrdersAsync(int pageNumber = 1, int pageSize = 10)
        {
            return await _httpClient.GetFromJsonAsync<PagedResult<OrderDto>>($"api/orders?pageNumber={pageNumber}&pageSize={pageSize}");
        }

        public async Task<OrderDto?> GetOrderByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<OrderDto>($"api/orders/{id}");
        }

        public async Task<OrderDto?> CreateOrderAsync(CreateOrderDto order)
        {
            var response = await _httpClient.PostAsJsonAsync("api/orders", order);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<OrderDto>();
            }
            return null;
        }
    }

}
