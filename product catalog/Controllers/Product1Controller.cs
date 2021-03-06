using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using product_catalog.Context;
using product_catalog.Models;

namespace product_catalog
{
    public class Product1Controller : Controller
    {
        private readonly ProductContext _context;

        public Product1Controller(ProductContext context)
        {
            _context = context;
        }

        // GET: Product1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Product1s.ToListAsync());
        }

        // GET: Product1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product1 = await _context.Product1s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product1 == null)
            {
                return NotFound();
            }

            return View(product1);
        }

        // GET: Product1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PurchasePrice,SellPrice,Description,Quantity")] Product1 product1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product1);
        }

        // GET: Product1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product1 = await _context.Product1s.FindAsync(id);
            if (product1 == null)
            {
                return NotFound();
            }
            return View(product1);
        }

        // POST: Product1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PurchasePrice,SellPrice,Description,Quantity")] Product1 product1)
        {
            if (id != product1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Product1Exists(product1.Id))
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
            return View(product1);
        }

        // GET: Product1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product1 = await _context.Product1s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product1 == null)
            {
                return NotFound();
            }

            return View(product1);
        }

        // POST: Product1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product1 = await _context.Product1s.FindAsync(id);
            _context.Product1s.Remove(product1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Product1Exists(int id)
        {
            return _context.Product1s.Any(e => e.Id == id);
        }
    }
}
