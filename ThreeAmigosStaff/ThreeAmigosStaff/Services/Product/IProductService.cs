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

        Task<IEnumerable<ProductHistoryDto>> GetPriceHistoryAsync(int Id);

        Task<IEnumerable<ReviewDto>> GetReviewsAsync(int Id);

        bool GetProductExists(int Id);

        bool GetReviewsExists(int Id);

        Task<ProductDto> PutProductAsync(ProductDto productDto);

        Task<ReviewDto> PutReviewAsync(ReviewDto reviewDto);

        Task<ProductDto> PostProductAsync(ProductDto ProductDto);

        Task<ProductDto> EditProductDetailsAsync(int Id);

        Task<ReviewDto> EditReviewDetailsAsync(int Id);

        Task<ProductDto> GetDeleteProductAsync(int Id);

        Task<ProductDto> DeleteProductAsync(int Id);
    }
}
