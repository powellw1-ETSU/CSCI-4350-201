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
    public class CommonSizesController : Controller
    {
        private readonly Bikeshop_ProjectContext _context;

        public CommonSizesController(Bikeshop_ProjectContext context)
        {
            _context = context;
        }

        // GET: CommonSizes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CommonSizes.ToListAsync());
        }

        // GET: CommonSizes/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commonSizes = await _context.CommonSizes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (commonSizes == null)
            {
                return NotFound();
            }

            return View(commonSizes);
        }

        // GET: CommonSizes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CommonSizes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MODELTYPE,FRAMESIZE")] CommonSizes commonSizes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commonSizes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(commonSizes);
        }

        // GET: CommonSizes/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commonSizes = await _context.CommonSizes.FindAsync(id);
            if (commonSizes == null)
            {
                return NotFound();
            }
            return View(commonSizes);
        }

        // POST: CommonSizes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("ID,MODELTYPE,FRAMESIZE")] CommonSizes commonSizes)
        {
            if (id != commonSizes.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commonSizes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommonSizesExists(commonSizes.ID))
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
            return View(commonSizes);
        }

        // GET: CommonSizes/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commonSizes = await _context.CommonSizes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (commonSizes == null)
            {
                return NotFound();
            }

            return View(commonSizes);
        }

        // POST: CommonSizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var commonSizes = await _context.CommonSizes.FindAsync(id);
            _context.CommonSizes.Remove(commonSizes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommonSizesExists(decimal id)
        {
            return _context.CommonSizes.Any(e => e.ID == id);
        }
    }
}
