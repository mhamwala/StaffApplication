using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ThreeAmigosPurchase.Services;

namespace ThreeAmigosStaff.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly ILogger _logger;
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(ILogger<PurchaseController> logger,
             IPurchaseService purchaseService)
        {
            _logger = logger;
            _purchaseService = purchaseService;
        }

        // GET: Purchase
        public async Task<IActionResult> Index()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable<PurchaseDto> purchases = null;
            try
            {
                purchases = await _purchaseService.GetPurchaseAsync();
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using purchase service.");
                purchases = Array.Empty<PurchaseDto>();
            }

            return View(purchases.ToList());
        }

        // GET: Purchase/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PurchaseDto purchases = null;
            try
            {
                purchases = await _purchaseService.GetPurchaseDetailsAsync(id);
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using staff service.");
            }

            return View(purchases);
        }

        // GET: Purchase/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Purchase/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,productId,ProductQuantity,status")] PurchaseDto purchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _purchaseService.PostPurchaseAsync(new PurchaseDto
                {
                    productID = purchase.productID,
                    ProductQuantity = purchase.ProductQuantity,
                    status = purchase.status
                });
                return RedirectToAction(nameof(Index));
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using staff service.");
            }
            return View(purchase);
        }

        //// GET: Purchase/Accept/5
        //public async Task<IActionResult> Accept(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var purchase = await _context.Purchase.FindAsync(id);
        //    if (purchase == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(purchase);
        //}

        // PUT: Purchase/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PurchaseDto purchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var reponse = await _purchaseService.PutPurchaseAsync(purchase);
                if (!PurchaseExists(id))
                {
                    return NotFound();
                }
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using Purchase EDIT PUT REquest.");
            }
            return RedirectToAction(nameof(Index));
        }

        //// POST: Purchase/Accept/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Accept(int id, [Bind("Id,ProductName,UserId,UserName,Quantity,Price,Date,Accepted")] Purchase purchase)
        //{
        //    if (id != purchase.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(purchase);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PurchaseExists(purchase.Id))
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
        //    return View(purchase);
        //}

        // GET: api/purchase/5
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            PurchaseDto purchase = null;
            try
            {
                purchase = await _purchaseService.GetDeletePurchaseAsync(id);
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using purchase service.");
            }

            return View(purchase);
        }

        // Delete: api/Purchase/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchase = await _purchaseService.DeletePurchaseAsync(id);
            if (purchase == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseExists(int id)
        {
            return _purchaseService.GetPurchaseExists(id);
        }
    }
}
