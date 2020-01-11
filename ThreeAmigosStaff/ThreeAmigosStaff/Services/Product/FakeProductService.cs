using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThreeAmigosProduct.Services
{
    public class FakeProductService : IProductService
    {
        public List<ProductDto> _product = new List<ProductDto>
        {
            new ProductDto { Id = 21, Name = "Ballons", Price = 1, Stock = 3 },
            new ProductDto { Id = 22, Name = "Kite", Price = 10.30, Stock = 4 },
            new ProductDto { Id = 23, Name = "Phone", Price = 19.23, Stock = 3 },
            new ProductDto { Id = 24, Name = "Wallet", Price = 1.99, Stock = 30 }
        };

        public List<ProductHistoryDto> _productHistory = new List<ProductHistoryDto>
        {
            new ProductHistoryDto { Id = 21, ProductId = 2, Price = 1}
        };

        public List<ReviewDto> _reviews = new List<ReviewDto>
        {
            new ReviewDto { Id = 3, CustomerID = 13, ProductID = 34, Rating = 1, Comments = "not to good", Visible = false }
        };

        public Task<IEnumerable<ProductDto>> GetProductAsync()
        {
            return Task.FromResult(_product.AsEnumerable());
        }

        Task<ProductDto> IProductService.GetProductDetailsAsync(int Id)
        {
            var product = _product.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(product);
        }

        Task<ProductDto> IProductService.PostProductAsync(ProductDto product)
        {
            _product.Add(product);
            return Task.FromResult(product);
        }

        Task<ProductDto> IProductService.PutProductAsync(ProductDto product)
        {
            _product.Add(product);
            return Task.FromResult(product);
        }

        Task<ReviewDto> IProductService.PutReviewAsync(ReviewDto review)
        {
            _reviews.Add(review);
            return Task.FromResult(review);
        }

        Task<ProductDto> IProductService.EditProductDetailsAsync(int Id)
        {
            var product = _product.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(product);
        }

        Task<ReviewDto> IProductService.EditReviewDetailsAsync(int Id)
        {
            var review = _reviews.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(review);
        }

        public Task<ProductDto> GetDeleteProductAsync(int Id)
        {
            var product = _product.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(product);
        }

        public Task<IEnumerable<ProductDto>> GetProductsAsync(int Id)
        {
            return Task.FromResult(_product.AsEnumerable());
        }

        public Task<ProductDto> DeleteProductAsync(int Id)
        {
            var product = _product.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(product);
        }

        public bool GetProductExists(int Id)
        {
            return true;
        }

        public bool GetReviewsExists(int Id)
        {
            return true;
        }

        public Task<IEnumerable<ProductHistoryDto>> GetPriceHistoryAsync(int Id)
        {
            return Task.FromResult(_productHistory.AsEnumerable());
        }

        public Task<IEnumerable<ReviewDto>> GetReviewsAsync(int Id)
        {
            return Task.FromResult(_reviews.AsEnumerable());
        }
    }
}
