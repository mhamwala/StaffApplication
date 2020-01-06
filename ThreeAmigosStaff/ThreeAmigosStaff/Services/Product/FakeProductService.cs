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

        Task<ProductDto> IProductService.EditProductDetailsAsync(int Id)
        {
            var product = _product.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(product);
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
    }
}
