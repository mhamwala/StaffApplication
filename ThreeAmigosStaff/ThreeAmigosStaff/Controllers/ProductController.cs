using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ThreeAmigosProduct.Services;
using ThreeAmigosReview.Services;

namespace ThreeAmigosProduct.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger _logger;
        private readonly IProductService _productService;
        private readonly IReviewService _reviewService;

        public ProductController(ILogger<ProductController> logger,
             IProductService productService, IReviewService reviewService)
        {
            _logger = logger;
            _productService = productService;
            _reviewService = reviewService;
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

            ProductDto products = null;
            try
            {
                products = await _productService.GetProductDetailsAsync(id);
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using Product service (Price History).");
            }

            return View(products);
        }

        // GET: Product/Reviews/5
        // when Review id equals ProductId
        public async Task<IActionResult> Review(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable<ReviewDto> reviews = null;
            try
            {
                reviews = await _reviewService.GetReviewDetailsListAsync(id);
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using GET-REVIEWS: product service.");
                reviews = Array.Empty<ReviewDto>();
            }
            return View(reviews.ToList());
        }

        // GET: Stock
        public async Task<IActionResult> Stock()
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
                _logger.LogWarning("Exception Occured using product service.");
                products = Array.Empty<ProductDto>();
            }

            return View(products.ToList());
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
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using staff service.");
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

        //// POST: Product/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Stock")] Product product)
        //{
        //    if (id != product.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(product);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProductExists(product.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(product);
        //}

        //// GET: Product/Resell/5
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

        //private bool ProductExists(int id)
        //{
        //    return _context.Product.Any(e => e.Id == id);
        //}
    }
}
