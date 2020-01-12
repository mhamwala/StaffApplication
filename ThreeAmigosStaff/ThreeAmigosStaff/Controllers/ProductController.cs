using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ThreeAmigosProduct.Services;

namespace ThreeAmigosProduct.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger,
             IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable<ProductDto> products = null;
            try
            {
                products = await _productService.GetProductAsync();
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using Product service (Getting all products).");
                products = Array.Empty<ProductDto>();
            }

            return View(products.ToList());
        }

        // GET: Product/PriceHistory/5
        public async Task<IActionResult> PriceHistory(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable<ProductHistoryDto> products = null;
            try
            {
                products = await _productService.GetPriceHistoryAsync(id);
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using Product service (Price History).");
            }

            return View(products);
        }

        // GET: Stock
        public async Task<IActionResult> Stock(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ProductDto stock = null;
            try
            {
                stock = await _productService.GetProductDetailsAsync(id);
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using product service.");
                //products = Array.Empty<ProductDto>();
            }

            return View(stock);
        }

        // GET: Reviews
        public async Task<IActionResult> Reviews(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable<ReviewDto> reviews = null;
            try
            {
                reviews = await _productService.GetReviewsAsync(id);
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using Review.");
            }

            return View(reviews);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> EditReview(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var reviews = await _productService.EditReviewDetailsAsync(id);
            if (reviews == null)
            {
                return NotFound();
            }
            return View(reviews);
        }

        // PUT: Edit/Reviews
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditReview(int id, ReviewDto review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var reponse = await _productService.PutReviewAsync(review);
                if (!ReviewsExists(id))
                {
                    return NotFound();
                }
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using Review EDIT PUT REquest.");
            }
            return RedirectToAction(nameof(Index));
        }

        // PUT: Product/Update/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Stock(int id, ProductDto product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var reponse = await _productService.PutProductAsync(product);
                if (!ProductExists(id))
                {
                    return NotFound();
                }
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using Product EDIT PUT REquest.");
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Price,Stock")] ProductDto product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _productService.PostProductAsync(new ProductDto
                {
                    Name = product.Name,
                    Price = product.Price,
                    Stock = product.Stock
                });
                return RedirectToAction(nameof(Index));
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using Product service.");
            }
            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var product = await _productService.EditProductDetailsAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // PUT: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductDto product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var reponse = await _productService.PutProductAsync(product);
                if (!ProductExists(id))
                {
                    return NotFound();
                }
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using Product EDIT PUT REquest.");
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Product/Resell/5
        public async Task<IActionResult> Resell(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var product = await _productService.EditProductDetailsAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: api/Product/5
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            ProductDto product = null;
            try
            {
                product = await _productService.GetDeleteProductAsync(id);
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using product service.");
            }

            return View(product);
        }

        // Delete: api/Product/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _productService.DeleteProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            await _productService.GetProductAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _productService.GetProductExists(id);
        }

        private bool ReviewsExists(int id)
        {
            return _productService.GetReviewsExists(id);
        }
    }
}
