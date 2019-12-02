using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ThreeAmigosProduct.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;

        public ProductService(HttpClient client)
        {
            client.BaseAddress = new System.Uri("http://localhost:5001/");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        //Get all Product
        public async Task<IEnumerable<ProductDto>> GetProductAsync()
        {
            var response = await _client.GetAsync("Product/");
            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var product = await response.Content.ReadAsAsync<IEnumerable<ProductDto>>();
            return product;

        }

        //Get all Products
        public async Task<IEnumerable<ProductDto>> GetProductsAsync(int Id)
        {
            var response = await _client.GetAsync("Product/" + Id);
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
            var response = await _client.GetAsync("Product/details/" + Id);
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
            var response = await _client.PostAsJsonAsync("Product/", products);
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
            var response = await _client.GetAsync("Product/edit/" + Id);
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
            var response = await _client.GetAsync("Product/delete/" + Id);
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
