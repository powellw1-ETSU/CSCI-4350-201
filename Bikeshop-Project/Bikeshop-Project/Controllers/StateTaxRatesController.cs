using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bikeshop_Project.Data;
using Bikeshop_Project.Models;

namespace Bikeshop_Project.Controllers
{
    public class StateTaxRatesController : Controller
    {
        private readonly Bikeshop_ProjectContext _context;

        public StateTaxRatesController(Bikeshop_ProjectContext context)
        {
            _context = context;
        }

        // GET: StateTaxRates
        public async Task<IActionResult> Index()
        {
            return View(await _context.StateTaxRate.ToListAsync());
        }

        // GET: StateTaxRates/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stateTaxRate = await _context.StateTaxRate
                .FirstOrDefaultAsync(m => m.STATE == id);
            if (stateTaxRate == null)
            {
                return NotFound();
            }

            return View(stateTaxRate);
        }

        // GET: StateTaxRates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StateTaxRates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("STATE,TAXRATE")] StateTaxRate stateTaxRate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stateTaxRate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stateTaxRate);
        }

        // GET: StateTaxRates/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stateTaxRate = await _context.StateTaxRate.FindAsync(id);
            if (stateTaxRate == null)
            {
                return NotFound();
            }
            return View(stateTaxRate);
        }

        // POST: StateTaxRates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("STATE,TAXRATE")] StateTaxRate stateTaxRate)
        {
            if (id != stateTaxRate.STATE)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stateTaxRate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StateTaxRateExists(stateTaxRate.STATE))
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
            return View(stateTaxRate);
        }

        // GET: StateTaxRates/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stateTaxRate = await _context.StateTaxRate
                .FirstOrDefaultAsync(m => m.STATE == id);
            if (stateTaxRate == null)
            {
                return NotFound();
            }

            return View(stateTaxRate);
        }

        // POST: StateTaxRates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var stateTaxRate = await _context.StateTaxRate.FindAsync(id);
            _context.StateTaxRate.Remove(stateTaxRate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StateTaxRateExists(string id)
        {
            return _context.StateTaxRate.Any(e => e.STATE == id);
        }
    }
}
