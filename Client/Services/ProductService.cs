using BlazorEcommerce.Shared;

using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public List<Product> Products { get; set; }

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task GetProductsAsync()
        {
            var res = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>("/api/Product");
            if (res != null && res.Success && res.Data != null)
                Products = res.Data;
        }
    }
}
