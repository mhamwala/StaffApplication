using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ThreeAmigosOrder.Services;

namespace ThreeAmigosOrder.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger _logger;
        private readonly IOrderService _orderService;

        public OrderController(ILogger<OrderController> logger,
             IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        // GET: Order
        public async Task<IActionResult> Index()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable<OrderDto> orders = null;
            try
            {
                orders = await _orderService.GetOrderAsync();
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using HOME: order service.");
                orders = Array.Empty<OrderDto>();
            }

            return View(orders.ToList());
        }

        // GET: Order/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            OrderDto orders = null;
            try
            {
                orders = await _orderService.GetOrderDetailsAsync(id);
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using GET-DETAILS: order service.");
            }
            return View(orders);
        }

        // GET: Order/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerID,ProductID,Total,Quantity,ShippingAddress,OrderDate,ShippingDate")] OrderDto order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _orderService.PostOrderAsync(new OrderDto
                {
                    CustomerID = order.CustomerID,
                    ProductID = order.ProductID,
                    Total = order.Total,
                    Quantity = order.Quantity,
                    ShippingAddress = order.ShippingAddress,
                    OrderDate = order.OrderDate,
                    ShippingDate = order.ShippingDate
                });
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using POST: staff service.");
            }
            return View(order);
        }

        //GET: Order/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var order = await _orderService.EditOrderDetailsAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        ////// POST: Order/Edit/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerID,OrderID,Total,Quantity,ShippingAddress,OrderDate,ShippingDate")] OrderDto order)
        //{
        //    if (id != order.Id)
        //    {
        //        return NotFound();
        //    }

        //    await _orderService.PutOrderAsync(order);

        //    //try
        //    //{
        //    //    await _context.SaveChangesAsync();
        //    //}
        //    //catch
        //    //{

        //    //}

        //    return RedirectToAction(nameof(Index));
        //}

        // POST: Order/Create
        [HttpPut]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerID,OrderID,Total,Quantity,ShippingAddress,OrderDate,ShippingDate")] OrderDto order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _orderService.PutOrderAsync(order);
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using staff EDIT PUT REquest.");
            }
            return NoContent();
        }

        // GET: api/Order/5
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            OrderDto order = null;
            try
            {
                order = await _orderService.GetDeleteOrderAsync(id);
            }
            catch (HttpRequestException)
            {
                _logger.LogError("THIS IS THE ORDER inside catch   " + order);
                _logger.LogWarning("Exception Occured using order service.");
            }

            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _orderService.DeleteOrderAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            await _orderService.GetOrderAsync();

            return RedirectToAction(nameof(Index));
        }

        //private bool OrderExists(int id)
        //{
        //    return _context.Order.Any(e => e.Id == id);
        //}
    }
}
