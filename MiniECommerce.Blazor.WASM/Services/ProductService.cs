using MiniECommerce.Shared.Common;
using MiniECommerce.Shared.DTOs;
using System.Net.Http.Json;

namespace MiniECommerce.Blazor.WASM.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PagedResult<ProductDto>?> GetProductsAsync(int pageNumber = 1, int pageSize = 10)
        {
            return await _httpClient.GetFromJsonAsync<PagedResult<ProductDto>>($"api/products?pageNumber={pageNumber}&pageSize={pageSize}");
        }

        public async Task<ProductDto?> CreateProductAsync(CreateProductDto product)
        {
            var response = await _httpClient.PostAsJsonAsync("api/products", product);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ProductDto>();
            }
            return null;
        }
    }
}

