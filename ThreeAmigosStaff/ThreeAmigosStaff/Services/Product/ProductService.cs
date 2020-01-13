using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ThreeAmigosProduct.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        private readonly ILogger _logger;
        private productsContext dbContext;

        public ProductService(HttpClient client, ILogger<ProductService> logger)
        {
            client.BaseAddress = new Uri("https://manage-products-api.azurewebsites.net/api/");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
            _logger = logger;
        }

        public ProductService(productsContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Get all Product
        public async Task<IEnumerable<ProductDto>> GetProductAsync()
        {
            var response = await _client.GetAsync("products/");
            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                _logger.LogWarning("FAIling to do stuff.");
                return null;
            }
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
            var response = await _client.GetAsync("products/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var productDetails = await response.Content.ReadAsAsync<ProductDto>();
            return productDetails;
        }

        //Get Product Price History Details
        public async Task<IEnumerable<ProductHistoryDto>> GetPriceHistoryAsync(int Id)
        {
            var response = await _client.GetAsync("productsHistory/PRID/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                _logger.LogWarning("FAIling to do stuff.");
                return null;
            }
            response.EnsureSuccessStatusCode();
            var priceHistory = await response.Content.ReadAsAsync<IEnumerable<ProductHistoryDto>>();
            return priceHistory;  
        }

        //Get Customer Reviews
        public async Task<IEnumerable<ReviewDto>> GetReviewsAsync(int id)
        {
            var response = await _client.GetAsync("reviews/PRID/" + id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                _logger.LogWarning("FAIling to do stuff.");
                return null;
            }
            response.EnsureSuccessStatusCode();
            var reviews = await response.Content.ReadAsAsync<IEnumerable<ReviewDto>>();
            return reviews;
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

        //Put New Product Member
        public async Task<ProductDto> PutProductAsync(ProductDto product)
        {
            var response = await _client.PutAsJsonAsync("products/" + product.Id, product);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ProductDto>();
        }

        //Put New Product Member
        public async Task<ReviewDto> PutReviewAsync(ReviewDto review)
        {
            var response = await _client.PutAsJsonAsync("reviews/" + review.Id, review);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ReviewDto>();
        }

        //Edit Individual Product Details
        public async Task<ProductDto> EditProductDetailsAsync(int Id)
        {
            var response = await _client.GetAsync("products/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var product = await response.Content.ReadAsAsync<ProductDto>();
            return product;
        }

        //Edit Individual Review Details
        public async Task<ReviewDto> EditReviewDetailsAsync(int Id)
        {
            var response = await _client.GetAsync("reviews/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var review = await response.Content.ReadAsAsync<ReviewDto>();
            return review;
        }

        //Get Edit Delete
        public async Task<ProductDto> GetDeleteProductAsync(int Id)
        {
            var response = await _client.DeleteAsync("products/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var product = await response.Content.ReadAsAsync<ProductDto>();
            return product;
        }

        //Delete
        public async Task<ProductDto> DeleteProductAsync(int Id)
        {
            var response = await _client.DeleteAsync("products/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var product = await response.Content.ReadAsAsync<ProductDto>();
            return product;
        }

        //Get Product Exists
        public bool GetProductExists(int Id)
        {
            var response = _client.GetAsync("products/" + Id);
            if (response.Equals(null))
            {
                _logger.LogError("Product does not exist in the database");
                return false;
            }
            return true;
        }

        //Get Reviews Exists
        public bool GetReviewsExists(int Id)
        {
            var response = _client.GetAsync("reviews/" + Id);
            if (response.Equals(null))
            {
                _logger.LogError("Review does not exist in the database");
                return false;
            }
            return true;
        }
    }
}
