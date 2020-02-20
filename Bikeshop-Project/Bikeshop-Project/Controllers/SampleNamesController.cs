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
    public class SampleNamesController : Controller
    {
        private readonly Bikeshop_ProjectContext _context;

        public SampleNamesController(Bikeshop_ProjectContext context)
        {
            _context = context;
        }

        // GET: SampleNames
        public async Task<IActionResult> Index()
        {
            return View(await _context.SampleName.ToListAsync());
        }

        // GET: SampleNames/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sampleName = await _context.SampleName
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sampleName == null)
            {
                return NotFound();
            }

            return View(sampleName);
        }

        // GET: SampleNames/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SampleNames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LASTNAME,FIRSTNAME,GENDER")] SampleName sampleName)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sampleName);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sampleName);
        }

        // GET: SampleNames/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sampleName = await _context.SampleName.FindAsync(id);
            if (sampleName == null)
            {
                return NotFound();
            }
            return View(sampleName);
        }

        // POST: SampleNames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("ID,LASTNAME,FIRSTNAME,GENDER")] SampleName sampleName)
        {
            if (id != sampleName.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sampleName);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SampleNameExists(sampleName.ID))
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
            return View(sampleName);
        }

        // GET: SampleNames/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sampleName = await _context.SampleName
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sampleName == null)
            {
                return NotFound();
            }

            return View(sampleName);
        }

        // POST: SampleNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var sampleName = await _context.SampleName.FindAsync(id);
            _context.SampleName.Remove(sampleName);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SampleNameExists(decimal id)
        {
            return _context.SampleName.Any(e => e.ID == id);
        }
    }
}
