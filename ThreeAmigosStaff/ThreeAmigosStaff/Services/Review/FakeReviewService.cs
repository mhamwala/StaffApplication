using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThreeAmigosReview.Services
{
    public class FakeReviewService : IReviewService
    {
        public List<ReviewDto> _review = new List<ReviewDto>
        {
            new ReviewDto { Id = 21, CustomerID  = 3, ProductID = 21, Comments = "Good", Rating = 5, Visible = true },
            new ReviewDto { Id = 21, CustomerID  = 3, ProductID = 21, Comments = "Bad", Rating = 5, Visible = true },
            new ReviewDto { Id = 21, CustomerID  = 3, ProductID = 21, Comments = "Ok", Rating = 5, Visible = true },
            new ReviewDto { Id = 22, CustomerID  = 5, ProductID = 22, Comments = "Ok", Rating = 5, Visible = true },
            new ReviewDto { Id = 23, CustomerID  = 4, ProductID = 23, Comments = "Bad", Rating = 5, Visible = true },
            new ReviewDto { Id = 24, CustomerID  = 6, ProductID = 24, Comments = "Good", Rating = 5, Visible = true },
            new ReviewDto { Id = 25, CustomerID  = 6, ProductID = 24, Comments = "Good", Rating = 5, Visible = true }
        };

        public Task<IEnumerable<ReviewDto>> GetReviewAsync()
        {
            return Task.FromResult(_review.AsEnumerable());
        }

        Task<ReviewDto> IReviewService.GetReviewDetailsAsync(int Id)
        {
            var review = _review.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(review);
        }

        Task<ReviewDto> IReviewService.PostReviewAsync(ReviewDto review)
        {
            _review.Add(review);
            return Task.FromResult(review);
        }

        Task<ReviewDto> IReviewService.EditReviewDetailsAsync(int Id)
        {
            var review = _review.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(review);
        }

        public Task<ReviewDto> GetDeleteReviewAsync(int Id)
        {
            var review = _review.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(review);
        }

        public Task<IEnumerable<ReviewDto>> GetReviewsAsync(int Id)
        {
            return Task.FromResult(_review.AsEnumerable());
        }

        public Task<IEnumerable<ReviewDto>> GetReviewDetailsListAsync(int Id)
        {
            return Task.FromResult(_review.AsEnumerable());
        }
    }
}
