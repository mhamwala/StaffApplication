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

            StaffDto staffs = new StaffDto();
            try
            {
                staffs = await _staffService.GetStaffDetailsAsync(id);
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using staff service.");
            }
            return View(staffs);
        }

        // GET: Staff/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Password,Address,PostCode,Telephone,IsManagement")] StaffDto staff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _staffService.PostStaffAsync(new StaffDto
                {
                    Name = staff.Name,
                    Email = staff.Email,
                    Address = staff.Address,
                    PostCode = staff.PostCode,
                    Telephone = staff.Telephone,
                    IsManagement = staff.IsManagement
                });
                return RedirectToAction(nameof(Index));
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using staff service.");
            }
            return View(staff);
        }

        // GET: Staff/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var staff = await _staffService.EditStaffDetailsAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            return View(staff);
        }

        // PUT: Staff/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StaffDto staff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var reponse = await _staffService.PutStaffAsync(staff);
                if (!StaffExists(id))
                {
                    return NotFound();
                }
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using Staff EDIT PUT REquest.");
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: api/staff/5
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            StaffDto staff = null;
            try
            {
                staff = await _staffService.GetDeleteStaffAsync(id);
            }
            catch (HttpRequestException)
            {
                _logger.LogWarning("Exception Occured using purchase service.");
            }

            return View(staff);
        }

        // Delete: api/staff/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staff = await _staffService.DeleteStaffAsync(id);
            if (staff == null)
            {
                return NotFound();
            }

            await _staffService.GetStaffAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool StaffExists(int id)
        {
            return _staffService.GetStaffExists(id);
        }
    }
}
