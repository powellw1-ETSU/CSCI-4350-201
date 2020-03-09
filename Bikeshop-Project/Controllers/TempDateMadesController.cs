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
    public class TempDateMadesController : Controller
    {
        private readonly Bikeshop_ProjectContext _context;

        public TempDateMadesController(Bikeshop_ProjectContext context)
        {
            _context = context;
        }

        // GET: TempDateMades
        public async Task<IActionResult> Index()
        {
            return View(await _context.TempDateMade.ToListAsync());
        }

        // GET: TempDateMades/Details/5
        public async Task<IActionResult> Details(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tempDateMade = await _context.TempDateMade
                .FirstOrDefaultAsync(m => m.DATEVALUE == id);
            if (tempDateMade == null)
            {
                return NotFound();
            }

            return View(tempDateMade);
        }

        // GET: TempDateMades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TempDateMades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DATEVALUE,MADECOUNT")] TempDateMade tempDateMade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tempDateMade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tempDateMade);
        }

        // GET: TempDateMades/Edit/5
        public async Task<IActionResult> Edit(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tempDateMade = await _context.TempDateMade.FindAsync(id);
            if (tempDateMade == null)
            {
                return NotFound();
            }
            return View(tempDateMade);
        }

        // POST: TempDateMades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DateTime id, [Bind("DATEVALUE,MADECOUNT")] TempDateMade tempDateMade)
        {
            if (id != tempDateMade.DATEVALUE)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tempDateMade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TempDateMadeExists(tempDateMade.DATEVALUE))
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
            return View(tempDateMade);
        }

        // GET: TempDateMades/Delete/5
        public async Task<IActionResult> Delete(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tempDateMade = await _context.TempDateMade
                .FirstOrDefaultAsync(m => m.DATEVALUE == id);
            if (tempDateMade == null)
            {
                return NotFound();
            }

            return View(tempDateMade);
        }

        // POST: TempDateMades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(DateTime id)
        {
            var tempDateMade = await _context.TempDateMade.FindAsync(id);
            _context.TempDateMade.Remove(tempDateMade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TempDateMadeExists(DateTime id)
        {
            return _context.TempDateMade.Any(e => e.DATEVALUE == id);
        }
    }
}
