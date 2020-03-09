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
    public class WorkAreasController : Controller
    {
        private readonly Bikeshop_ProjectContext _context;

        public WorkAreasController(Bikeshop_ProjectContext context)
        {
            _context = context;
        }

        // GET: WorkAreas
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkArea.ToListAsync());
        }

        // GET: WorkAreas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workArea = await _context.WorkArea
                .FirstOrDefaultAsync(m => m.WORKAREAID == id);
            if (workArea == null)
            {
                return NotFound();
            }

            return View(workArea);
        }

        // GET: WorkAreas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkAreas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WORKAREAID,DESCRIPTION")] WorkArea workArea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workArea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workArea);
        }

        // GET: WorkAreas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workArea = await _context.WorkArea.FindAsync(id);
            if (workArea == null)
            {
                return NotFound();
            }
            return View(workArea);
        }

        // POST: WorkAreas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("WORKAREAID,DESCRIPTION")] WorkArea workArea)
        {
            if (id != workArea.WORKAREAID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workArea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkAreaExists(workArea.WORKAREAID))
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
            return View(workArea);
        }

        // GET: WorkAreas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workArea = await _context.WorkArea
                .FirstOrDefaultAsync(m => m.WORKAREAID == id);
            if (workArea == null)
            {
                return NotFound();
            }

            return View(workArea);
        }

        // POST: WorkAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var workArea = await _context.WorkArea.FindAsync(id);
            _context.WorkArea.Remove(workArea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkAreaExists(string id)
        {
            return _context.WorkArea.Any(e => e.WORKAREAID == id);
        }
    }
}
