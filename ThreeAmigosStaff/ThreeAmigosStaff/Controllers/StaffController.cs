using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ThreeAmigosStaff.Services;

namespace ThreeAmigosStaff.Controllers
{
    public class StaffController : Controller
    {
        private readonly ILogger _logger;
        private readonly IStaffService _staffService;

        public StaffController(ILogger<StaffController> logger,
             IStaffService staffService)
        {
            _logger = logger;
            _staffService = staffService;
        }

        // GET: Staff
        public async Task<IActionResult> Index()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable<StaffDto> staffs = null;
            try
            {
                staffs = await _staffService.GetStaffAsync();
            }
            catch(HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using staff service.");
                staffs = Array.Empty<StaffDto>();
            }
            
            return View(staffs.ToList());
        }

        // GET: Staff/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            StaffDto staffs = null;
            try
            {
                staffs = await _staffService.GetStaffDetailsAsync(id);
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using staff service.");
                //staffs = Array.Empty<StaffDto>();
            }
            return View(staffs);
        }

        // GET: Staff/Create
        public IActionResult Create()
        {
            return View();
        }

        //// POST: Staff/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name,Email,Password,Address,PostCode,Telephone,IsManagement")] Staff staff)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    try
        //    {
        //        await _staffService.PostStaffAsync(new StaffDto
        //        {
        //            Name = staff.Name,
        //            Email = staff.Email,
        //            Address = staff.Address,
        //            PostCode = staff.PostCode,
        //            Telephone = staff.Telephone,
        //            IsManagement = staff.IsManagement
        //        });
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch(HttpRequestException)
        //    {
        //        _logger.LogWarning("Exception Occured using staff service.");
        //    }
        //    return View(staff);
        //}

        // GET: Staff/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var staff = await _staffService.EditStaffDetailsAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            return View(staff);
        }

        //// POST: Staff/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Password,Address,PostCode,Telephone,IsManagement")] Staff staff)
        //{
        //    if (id != staff.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(staff);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!StaffExists(staff.Id))
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
        //    return View(staff);
        //}

        // GET: Staff/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var staff = await _staffService.GetDeleteStaffAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            return View(staff);
        }

        //// POST: Staff/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var staff = await _context.Staff.FindAsync(id);
        //    _context.Staff.Remove(staff);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool StaffExists(int id)
        //{
        //    return _context.Staff.Any(e => e.Id == id);
        //}
    }
}
