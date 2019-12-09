using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ThreeAmigosProduct.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        private readonly ILogger _logger;

        public ProductService(HttpClient client, ILogger<ProductService> logger)
        {
            client.BaseAddress = new System.Uri("http://manage-products-api/api/");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
            _logger = logger;
        }

        //Get all Product
        public async Task<IEnumerable<ProductDto>> GetProductAsync()
        {
            _logger.LogWarning("FAIling to do stuff.");
            Console.WriteLine("asjdhfjshd");
            var response = await _client.GetAsync("products/");
            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            System.Console.WriteLine(response.StatusCode);
            response.EnsureSuccessStatusCode();
            var product = await response.Content.ReadAsAsync<IEnumerable<ProductDto>>();
            return product;

        }

        //Get all Products
        public async Task<IEnumerable<ProductDto>> GetProductsAsync(int Id)
        {
            var response = await _client.GetAsync("products/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var product = await response.Content.ReadAsAsync<IEnumerable<ProductDto>>();
            return product;

        }

        //Get Individual Product Details
        public async Task<ProductDto> GetProductDetailsAsync(int Id)
        {
            var response = await _client.GetAsync("products/details/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var product = await response.Content.ReadAsAsync<ProductDto>();
            return product;
        }

        //Post New Product Member
        public async Task<ProductDto> PostProductAsync(ProductDto products)
        {
            var response = await _client.PostAsJsonAsync("products/", products);
            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var product = await response.Content.ReadAsAsync<ProductDto>();
            return product;
        }

        //Edit Individual Product Details
        public async Task<ProductDto> EditProductDetailsAsync(int Id)
        {
            var response = await _client.GetAsync("products/edit/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var product = await response.Content.ReadAsAsync<ProductDto>();
            return product;
        }

        //Get Edit Delete
        public async Task<ProductDto> GetDeleteProductAsync(int Id)
        {
            var response = await _client.GetAsync("products/delete/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var product = await response.Content.ReadAsAsync<ProductDto>();
            return product;
        }
    }
}
