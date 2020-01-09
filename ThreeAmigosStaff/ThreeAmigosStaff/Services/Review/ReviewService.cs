using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ThreeAmigosPurchase.Services;

namespace ThreeAmigosReview.Services
{
    public class ReviewService : IReviewService
    {
        private readonly HttpClient _client;
        private readonly ILogger _logger;

        public ReviewService(HttpClient client, ILogger<PurchaseDto> logger)
        {
            client.BaseAddress = new System.Uri("https://managereviewsapi.azurewebsites.net/api/");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
            _logger = logger;
        }

        //Get all Review
        public async Task<IEnumerable<ReviewDto>> GetReviewAsync()
        {
            var response = await _client.GetAsync("Review/");
            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var review = await response.Content.ReadAsAsync<IEnumerable<ReviewDto>>();
            return review;

        }

        //Get all Reviews
        public async Task<IEnumerable<ReviewDto>> GetReviewsAsync(int Id)
        {
            var response = await _client.GetAsync("Review/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var review = await response.Content.ReadAsAsync<IEnumerable<ReviewDto>>();
            return review;
        }

        //Get Individual Review Details
        public async Task<ReviewDto> GetReviewDetailsAsync(int Id)
        {
            var response = await _client.GetAsync("Review/details/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var review = await response.Content.ReadAsAsync<ReviewDto>();
            return review;
        }

        //Post New Review Member
        public async Task<ReviewDto> PostReviewAsync(ReviewDto reviews)
        {
            var response = await _client.PostAsJsonAsync("Review/", reviews);
            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var review = await response.Content.ReadAsAsync<ReviewDto>();
            return review;
        }

        //Put New Review
        public async Task<ReviewDto> PutReviewAsync(ReviewDto review)
        {
            var response = await _client.PutAsJsonAsync("review/" + review.Id, review);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ReviewDto>();
        }

        //Edit Individual Review Details
        public async Task<ReviewDto> EditReviewDetailsAsync(int Id)
        {
            var response = await _client.GetAsync("Review/edit/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var review = await response.Content.ReadAsAsync<ReviewDto>();
            return review;
        }

        //Get Edit Delete
        public async Task<ReviewDto> GetDeleteReviewAsync(int Id)
        {
            var response = await _client.GetAsync("Review/delete/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var review = await response.Content.ReadAsAsync<ReviewDto>();
            return review;
        }

        public async Task<IEnumerable<ReviewDto>> GetReviewDetailsListAsync(int Id)
        {
            var response = await _client.GetAsync("Review/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var review = await response.Content.ReadAsAsync<IEnumerable<ReviewDto>>();
            return review;
        }

        //Delete
        public async Task<ReviewDto> DeleteReviewAsync(int Id)
        {
            var response = await _client.DeleteAsync("Review/" + Id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            var review = await response.Content.ReadAsAsync<ReviewDto>();
            return review;
        }

        //Get Review Exists
        public bool GetReviewExists(int Id)
        {
            var response = _client.GetAsync("Review/" + Id);
            if (response.Equals(null))
            {
                _logger.LogError("Review does not exist in the database");
                return false;
            }
            return true;
        }
    }
}
