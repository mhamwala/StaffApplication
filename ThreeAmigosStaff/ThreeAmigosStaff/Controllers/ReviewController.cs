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

        // GET: api/review/5
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            ReviewDto review = null;
            try
            {
                review = await _reviewService.GetDeleteReviewAsync(id);
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using purchase service.");
            }

            return View(review);
        }

        // Delete: api/review/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchase = await _reviewService.DeleteReviewAsync(id);
            if (purchase == null)
            {
                return NotFound();
            }

            await _reviewService.GetReviewAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
