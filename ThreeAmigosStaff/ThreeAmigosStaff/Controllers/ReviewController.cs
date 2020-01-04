using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ThreeAmigosReview.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThreeAmigosReview.Controllers
{
    public class ReviewController : Controller
    {
        //private readonly MvcReviewContext _context;
        private readonly ILogger _logger;
        private readonly IReviewService _reviewService;

        public ReviewController(ILogger<ReviewController> logger,
             IReviewService reviewService)
        {
            _logger = logger;
            _reviewService = reviewService;
        }

        // GET: Review
        public async Task<IActionResult> Index()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable<ReviewDto> reviews = null;
            try
            {
                reviews = await _reviewService.GetReviewAsync();
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using review service.");
                reviews = Array.Empty<ReviewDto>();
            }

            return View(reviews.ToList());
        }
    }
}
