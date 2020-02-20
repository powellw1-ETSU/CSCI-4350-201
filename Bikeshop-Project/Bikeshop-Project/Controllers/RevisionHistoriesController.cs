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
    public class RevisionHistoriesController : Controller
    {
        private readonly Bikeshop_ProjectContext _context;

        public RevisionHistoriesController(Bikeshop_ProjectContext context)
        {
            _context = context;
        }

        // GET: RevisionHistories
        public async Task<IActionResult> Index()
        {
            return View(await _context.RevisionHistory.ToListAsync());
        }

        // GET: RevisionHistories/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var revisionHistory = await _context.RevisionHistory
                .FirstOrDefaultAsync(m => m.ID == id);
            if (revisionHistory == null)
            {
                return NotFound();
            }

            return View(revisionHistory);
        }

        // GET: RevisionHistories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RevisionHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,VERSION,CHANGEDATE,NAME,REVISIONCOMMENTS")] RevisionHistory revisionHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(revisionHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(revisionHistory);
        }

        // GET: RevisionHistories/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var revisionHistory = await _context.RevisionHistory.FindAsync(id);
            if (revisionHistory == null)
            {
                return NotFound();
            }
            return View(revisionHistory);
        }

        // POST: RevisionHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("ID,VERSION,CHANGEDATE,NAME,REVISIONCOMMENTS")] RevisionHistory revisionHistory)
        {
            if (id != revisionHistory.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(revisionHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RevisionHistoryExists(revisionHistory.ID))
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
            return View(revisionHistory);
        }

        // GET: RevisionHistories/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var revisionHistory = await _context.RevisionHistory
                .FirstOrDefaultAsync(m => m.ID == id);
            if (revisionHistory == null)
            {
                return NotFound();
            }

            return View(revisionHistory);
        }

        // POST: RevisionHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var revisionHistory = await _context.RevisionHistory.FindAsync(id);
            _context.RevisionHistory.Remove(revisionHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RevisionHistoryExists(decimal id)
        {
            return _context.RevisionHistory.Any(e => e.ID == id);
        }
    }
}
