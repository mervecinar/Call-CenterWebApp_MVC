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
using System.Xml.Linq;
using static MessagePack.MessagePackSerializer;

namespace WebApplication13.Controllers
{


    public class CustomersController : Controller
    {
            private readonly BLM19417EContext _context;
            public CustomersController(BLM19417EContext context)
            {
                _context = context;
            }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
     




            return View(await _context.Customers.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> searchB(string search)
        {
            var searching = _context.Customers.Where(t => t.FirstName.ToLower().Contains(search.ToLower()));
            return View(nameof(Index), await searching.ToListAsync());
        }


        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
            {
                if (id == null || _context.Customers == null)
                {
                    return NotFound();
                }

                var customer = await _context.Customers
                    .FirstOrDefaultAsync(m => m.CustomerId == id);
                if (customer == null)
                {
                    return NotFound();
                }

                return View(customer);
            }



        // GET: Customers/Create
        public IActionResult Create()
        {
            var listele = (from type in _context.CosRepresantatives
                           select
                           new SelectListItem()
                           {
                               Text = type.FirstName,
                               Value = type.CosRepresantativeId.ToString()
                           }

                  ).ToList();

            listele.Insert(0, new SelectListItem()
            {

                Text = "      ",
                Value = String.Empty
            });


            ViewBag.ListofCust = listele;



            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("CustomerId,FirstName,LastName,country,phone,age,point,CosRepresantativeId")] Customer customer)
        {
            var listele = (from type in _context.CosRepresantatives
                           select
                           new SelectListItem()
                           {
                               Text = type.FirstName,
                               Value = type.CosRepresantativeId.ToString()
                           }

           ).ToList();

            listele.Insert(0, new SelectListItem()
            {

                Text = "      ",
                Value = String.Empty
            });


            ViewBag.ListofCust = listele;


            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Customer Created Successfully!";
                return RedirectToAction(nameof(Index));
            }
          
            return View(customer);
        }


        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
            {
                if (id == null || _context.Customers == null)
                {
                    return NotFound();
                }

                var customer = await _context.Customers.FindAsync(id);
                if (customer == null)
                {
                    return NotFound();
                }
                return View(customer);
            }



        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("CustomerId,FirstName,LastName,country,phone,age,point,CusRepresantativeId")] Customer customer)
            {
                var cus = await _context.Customers.FindAsync(id);
                _context.Entry(cus).State = EntityState.Detached;
                if (id != customer.CustomerId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(customer);
                        await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Customer Updated Successfully!";
                }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CustomerExists(customer.CustomerId))
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
                return View(customer);
            }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
            {
                if (id == null || _context.Customers == null)
                {
                    return NotFound();
                }

                var customer = await _context.Customers
                    .FirstOrDefaultAsync(m => m.CustomerId == id);
                if (customer == null)
                {
                    return NotFound();
                }

                return View(customer);
            }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                if (_context.Customers == null)
                {
                    return Problem("Entity set 'BLM19417EContext.Customers'  is null.");
         
            }
                var customer = await _context.Customers.FindAsync(id);
                if (customer != null)
                {
                    _context.Customers.Remove(customer);
                }

                await _context.SaveChangesAsync();
            TempData["AlertMessage"] = "Customer Deleted Successfully!";
            return RedirectToAction(nameof(Index));
            }

            private bool CustomerExists(int id)
            {
                return _context.Customers.Any(e => e.CustomerId == id);
            }
        }
    }

