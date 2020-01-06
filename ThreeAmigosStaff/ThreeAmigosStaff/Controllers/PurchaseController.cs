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
                //purchases = Array.Empty<StaffDto>();
            }

            return View(purchases);
        }

        //// GET: Purchase/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var purchase = await _context.Purchase
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (purchase == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(purchase);
        //}

        // GET: Purchase/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Purchase/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductName,UserId,UserName,Quantity,Price,Date,Accepted,CardNumber,SortCode,SecurityNumber")] PurchaseDto purchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _purchaseService.PostPurchaseAsync(new PurchaseDto
                {
                    ProductName = purchase.ProductName,
                    UserId = purchase.UserId,
                    UserName = purchase.UserName,
                    Quantity = purchase.Quantity,
                    Price = purchase.Price,
                    Date = purchase.Date,
                    Accepted = purchase.Accepted,
                    CardNumber = purchase.CardNumber,
                    SortCode = purchase.SortCode,
                    SecurityNumber = purchase.SecurityNumber
                });
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using staff service.");
            }
            return View(purchase);
        }

        //// GET: Purchase/Edit/5
        //public async Task<IActionResult> Edit(int? id)
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

        //// POST: Purchase/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,ProductName,UserId,UserName,Quantity,Price,Date,Accepted")] Purchase purchase)
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

            await _purchaseService.GetPurchaseAsync();

            return RedirectToAction(nameof(Index));
        }


        //private bool PurchaseExists(int id)
        //{
        //    return _context.Purchase.Any(e => e.Id == id);
        //}
    }
}
