using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    public class RequestComplaintsController : Controller
    {

            private readonly BLM19417EContext _context;

            public RequestComplaintsController(BLM19417EContext context)
            {
                _context = context;
            }

        // GET: RequestComplaints
           public async Task<IActionResult> Index()
            {
                return View(await _context.RequestComplaints.ToListAsync());
            }

        // GET: RequestComplaints/Details/5
        public async Task<IActionResult> Details(int? id)
            {
                if (id == null || _context.RequestComplaints == null)
                {
                    return NotFound();
                }

                var request = await _context.RequestComplaints.Include(d => d.Customer)
                    .FirstOrDefaultAsync(m => m.CustomerId == id);
                if (request == null)
                {
                    return NotFound();
                }

                return View(request);
            }

        // GET: RequestComplaints/Create
        public IActionResult Create()
            {
            ViewBag.Type = _context.RequestComplaints.ToString();
            return View();
            }

        // POST: RequestComplaints/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("RequestComplaintId,Type,Text,CustomerId")] RequestComplaint request)
            {
            ViewBag.Type = request.Type;
            if (ModelState.IsValid)
                {
                    _context.Add(request);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(request);
            }

        // GET: RequestComplaints/Edit/5
        public async Task<IActionResult> Edit(int? id)
            {
                if (id == null || _context.RequestComplaints == null)
                {
                    return NotFound();
                }

                var request = await _context.RequestComplaints.FindAsync(id);
                if (request == null)
                {
                    return NotFound();
                }
                return View(request);
            }

        // POST: RequestComplaints/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("RequestComplaintId,Type,Text,CustomerId")] RequestComplaint request)
            {
                if (id != request.RequestComplaintId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(request);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!RequestComplaintExists(request.RequestComplaintId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(request);
            }

        // GET: RequestComplaints/Delete/5
        public async Task<IActionResult> Delete(int? id)
            {
                if (id == null || _context.RequestComplaints == null)
                {
                    return NotFound();
                }

                var request = await _context.RequestComplaints
                    .FirstOrDefaultAsync(m => m.RequestComplaintId == id);
                if (request == null)
                {
                    return NotFound();
                }

                return View(request);
            }

        // POST: RequestComplaints/Delete/5
        [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                if (_context.RequestComplaints == null)
                {
                    return Problem("Entity set 'BLM19417EContext.RequestComplaints'  is null.");
                }
                var request = await _context.RequestComplaints.FindAsync(id);
                if (request != null)
                {
                    _context.RequestComplaints.Remove(request);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool RequestComplaintExists(int id)
            {
                return _context.RequestComplaints.Any(e => e.RequestComplaintId == id);
            }
        }
    }

