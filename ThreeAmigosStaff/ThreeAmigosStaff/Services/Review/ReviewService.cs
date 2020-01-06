using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ThreeAmigosPurchase.Services;

namespace ThreeAmigosReview.Services
{
    public class ReviewService : IReviewService
    {
        private readonly HttpClient _client;

        public ReviewService(HttpClient client)
        {
            client.BaseAddress = new System.Uri("https://managereviewsapi.azurewebsites.net/api/");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
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
    }
}
