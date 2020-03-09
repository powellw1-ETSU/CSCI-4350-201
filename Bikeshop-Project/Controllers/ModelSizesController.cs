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
    public class ModelSizesController : Controller
    {
        private readonly Bikeshop_ProjectContext _context;

        public ModelSizesController(Bikeshop_ProjectContext context)
        {
            _context = context;
        }

        // GET: ModelSizes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ModelSize.ToListAsync());
        }

        // GET: ModelSizes/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelSize = await _context.ModelSize
                .FirstOrDefaultAsync(m => m.id == id);
            if (modelSize == null)
            {
                return NotFound();
            }

            return View(modelSize);
        }

        // GET: ModelSizes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ModelSizes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,MODELTYPE,MSIZE,TOPTUBE,CHAINSTAY,TOTALLENGTH,GROUNDCLEARANCE,HEADTUBEANGLE,SEATTUBEANGEL")] ModelSize modelSize)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modelSize);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modelSize);
        }

        // GET: ModelSizes/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelSize = await _context.ModelSize.FindAsync(id);
            if (modelSize == null)
            {
                return NotFound();
            }
            return View(modelSize);
        }

        // POST: ModelSizes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("id,MODELTYPE,MSIZE,TOPTUBE,CHAINSTAY,TOTALLENGTH,GROUNDCLEARANCE,HEADTUBEANGLE,SEATTUBEANGEL")] ModelSize modelSize)
        {
            if (id != modelSize.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelSize);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelSizeExists(modelSize.id))
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
            return View(modelSize);
        }

        // GET: ModelSizes/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelSize = await _context.ModelSize
                .FirstOrDefaultAsync(m => m.id == id);
            if (modelSize == null)
            {
                return NotFound();
            }

            return View(modelSize);
        }

        // POST: ModelSizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var modelSize = await _context.ModelSize.FindAsync(id);
            _context.ModelSize.Remove(modelSize);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModelSizeExists(decimal id)
        {
            return _context.ModelSize.Any(e => e.id == id);
        }
    }
}
