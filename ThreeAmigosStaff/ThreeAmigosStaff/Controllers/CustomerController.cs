using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ThreeAmigosCustomer.Services;

namespace ThreeAmigosCustomer.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILogger _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger,
             ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        // GET: Customer
        public async Task<IActionResult> Index()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable<CustomerDto> customers = null;
            try
            {
                customers = await _customerService.GetCustomerAsync();
            }
            catch (HttpRequestException)
            {
                customers = Array.Empty<CustomerDto>();
            }

            return View(customers.ToList());
        }

        // GET: Customer/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CustomerDto customers = null;
            try
            {
                customers = await _customerService.GetCustomerDetailsAsync(id);
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using staff service.");
            }

            return View(customers);
        }

        // GET: Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Password,Address,PostCode,Telephone")] CustomerDto customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _customerService.PostCustomerAsync(new CustomerDto
                {
                    Name = customer.Name,
                    Email = customer.Email,
                    Password = customer.Password,
                    Address = customer.Address,
                    PostCode = customer.PostCode,
                    Telephone = customer.Telephone
                });
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using staff service.");
            }
            return View(customer);
        }

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var customer = await _customerService.EditCustomerDetailsAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        //// POST: Customer/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Password,Address,PostCode,Telephone")] Customer customer)
        //{
        //    if (id != customer.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(customer);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CustomerExists(customer.Id))
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
        //    return View(customer);
        //}

        // GET: api/Customer/5
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            CustomerDto customer = null;
            try
            {
                customer = await _customerService.GetDeleteCustomerAsync(id);
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using GET-Delete: in customer service.");
            }

            return View(customer);
        }

        // Delete: api/Customer/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _customerService.DeleteCustomerAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            await _customerService.GetCustomerAsync();

            return RedirectToAction(nameof(Index));
        }

        //private bool CustomerExists(int id)
        //{
        //    return _context.Customer.Any(e => e.Id == id);
        //}
    }
}
