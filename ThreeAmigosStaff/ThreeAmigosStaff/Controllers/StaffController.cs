using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MvcStaff.Models;
using ThreeAmigosStaff.Services;

namespace ThreeAmigosStaff.Controllers
{
    public class StaffController : Controller
    {
        //private readonly MvcStaffContext _context;
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
            if(ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable<StaffDto> staff = null;
            try
            {
                staff = (IEnumerable<StaffDto>)await _staffService.GetStaffAsync();
            }
            catch(HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using staff service.");
                staff = Array.Empty<StaffDto>();
            }
            return View(staff.ToList());
        }

        //// GET: Staff
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Staff.ToListAsync());
        //}

        //// GET: Staff/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var staff = await _context.Staff
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (staff == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(staff);
        //}

        //// GET: Staff/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Staff/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name,Email,Password,Address,PostCode,Telephone,IsManagement")] Staff staff)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(staff);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(staff);
        //}

        //// GET: Staff/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var staff = await _context.Staff.FindAsync(id);
        //    if (staff == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(staff);
        //}

        //// POST: Staff/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        //// GET: Staff/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var staff = await _context.Staff
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (staff == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(staff);
        //}

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
