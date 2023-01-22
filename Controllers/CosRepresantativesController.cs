using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication13.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using static MessagePack.MessagePackSerializer;

namespace WebApplication13.Controllers
{
    public class CosRepresantativesController : Controller
    {

        private readonly BLM19417EContext _context;
        public CosRepresantativesController(BLM19417EContext context)
        {
            _context = context;
        }

        // GET: CosRepresantatives
        public async Task<IActionResult> Index()
        {

            return View(await _context.CosRepresantatives.ToListAsync());
        }

        // GET: CosRepresantatives/Details/5
        public async Task<IActionResult> Details(int? id)
        {

 


            if (id == null || _context.CosRepresantatives == null)
            {
                return NotFound();
            }
     
            var cosrepresantative = await _context.CosRepresantatives.Include(d => d.Customers)
                .FirstOrDefaultAsync(m => m.CosRepresantativeId == id);
            if (cosrepresantative == null)
            {
                return NotFound();
            }

            return View(cosrepresantative);
        }
        [HttpPost]
        public async Task<IActionResult> searchA(string search)
        {
            var searching = _context.CosRepresantatives.Where(t => t.FirstName.ToLower().Contains(search.ToLower()));
            return View(nameof(Index), await searching.ToListAsync());
        }



        // GET: CosRepresantatives/Create
        public IActionResult Create()
        {
            var list = (from type in _context.Departments
                           select
                           new SelectListItem()
                           {
                               Text = type.DepartmentName,
                               Value = type.DepartmentId.ToString()
                           }

                  ).ToList();

            list.Insert(0, new SelectListItem()
            {

                Text = "      ",
                Value = String.Empty
            });


            ViewBag.ListofCust = list;



            return View();
        }

        // POST: CosRepresantatives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("CosRepresantativeId,FirstName,LastName,Country,DepartmentId")] CosRepresantative cosrepresantative)
        {
            var list = (from type in _context.Departments
                           select
                           new SelectListItem()
                           {
                               Text = type.DepartmentName,
                               Value = type.DepartmentId.ToString()
                           }

           ).ToList();

            list.Insert(0, new SelectListItem()
            {

                Text = "      ",
                Value = String.Empty
            });


            ViewBag.ListofCust = list;


            if (ModelState.IsValid)
            {
                _context.Add(cosrepresantative);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Cosrepresantative Created Successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(cosrepresantative);
        }

        // GET: CosRepresantatives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CosRepresantatives == null)
            {
                return NotFound();
            }

            var cosrepresantative = await _context.CosRepresantatives.FindAsync(id);
            if (cosrepresantative == null)
            {
                return NotFound();
            }
            return View(cosrepresantative);
        }


        // POST: CosRepresantatives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CosRepresantativeId,FirstName,LastName,Country,DepartmentId")] CosRepresantative cosrepresantative)
        {
            var cosrep = await _context.CosRepresantatives.FindAsync(id);
            _context.Entry(cosrep).State = EntityState.Detached;
            if (id != cosrepresantative.CosRepresantativeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cosrepresantative);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Cosrepresantative Updated Successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CosRepresantativeExists(cosrepresantative.CosRepresantativeId))
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
            return View(cosrepresantative);
        }

        // GET: CosRepresantatives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CosRepresantatives == null)
            {
                return NotFound();
            }

            var cosrepresantative = await _context.CosRepresantatives
                .FirstOrDefaultAsync(m => m.CosRepresantativeId == id);
            if (cosrepresantative == null)
            {
                return NotFound();
            }

            return View(cosrepresantative);
        }


        // POST: CosRepresantatives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CosRepresantatives == null)
            {
                return Problem("Entity set 'BLM19417EContext.CosRepresantatives'  is null.");
            }
            var cosrepresantative = await _context.CosRepresantatives.FindAsync(id);
            if (cosrepresantative != null)
            {
                _context.CosRepresantatives.Remove(cosrepresantative);
            }

            await _context.SaveChangesAsync();
            TempData["AlertMessage"] = "Cosrepresantative Deleted Successfully!";
            return RedirectToAction(nameof(Index));
        }

        private bool CosRepresantativeExists(int id)
        {
            return _context.CosRepresantatives.Any(e => e.CosRepresantativeId == id);
        }
    }



}

