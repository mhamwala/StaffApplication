using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThreeAmigosProduct.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductAsync();

        Task<IEnumerable<ProductDto>> GetProductsAsync(int Id);

        Task<ProductDto> GetProductDetailsAsync(int Id);

        bool GetProductExists(int Id);

        Task<ProductDto> PutProductAsync(ProductDto productDto);

        Task<ProductDto> PostProductAsync(ProductDto ProductDto);

        Task<ProductDto> EditProductDetailsAsync(int Id);

        Task<ProductDto> GetDeleteProductAsync(int Id);

        Task<ProductDto> DeleteProductAsync(int Id);
    }
}
