﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ThreeAmigosPurchase.Services;

namespace ThreeAmigosReview.Services
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDto>> GetReviewAsync();

        Task<IEnumerable<ReviewDto>> GetReviewsAsync(int Id);

        Task<ReviewDto> GetReviewDetailsAsync(int Id);

        Task<IEnumerable<ReviewDto>> GetReviewDetailsListAsync(int Id);

        bool GetReviewExists(int Id);

        Task<ReviewDto> PutReviewAsync(ReviewDto reviewDto);

        Task<ReviewDto> PostReviewAsync(ReviewDto ReviewDto);

        Task<ReviewDto> EditReviewDetailsAsync(int Id);

        Task<ReviewDto> GetDeleteReviewAsync(int Id);

        Task<ReviewDto> DeleteReviewAsync(int Id);
    }
}
