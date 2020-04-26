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
    public class PaintsController : Controller
    {
        private readonly Bikeshop_ProjectContext _context;

        public PaintsController(Bikeshop_ProjectContext context)
        {
            _context = context;
        }

        // GET: Paints
        public async Task<IActionResult> Index()
        {
            return View(await _context.Paint.ToListAsync());
        }

        // GET: Paints/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paint = await _context.Paint
                .FirstOrDefaultAsync(m => m.PAINTID == id);
            if (paint == null)
            {
                return NotFound();
            }

            return View(paint);
        }

        // GET: Paints/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Paints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PAINTID,COLORNAME,COLORSTYLE,COLORLIST,DATEINTRODUCED")] Paint paint)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paint);
        }

        // GET: Paints/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paint = await _context.Paint.FindAsync(id);
            if (paint == null)
            {
                return NotFound();
            }
            return View(paint);
        }

        // POST: Paints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("PAINTID,COLORNAME,COLORSTYLE,COLORLIST,DATEINTRODUCED")] Paint paint)
        {
            if (id != paint.PAINTID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaintExists(paint.PAINTID))
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
            return View(paint);
        }

        // GET: Paints/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paint = await _context.Paint
                .FirstOrDefaultAsync(m => m.PAINTID == id);
            if (paint == null)
            {
                return NotFound();
            }

            return View(paint);
        }

        // POST: Paints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var paint = await _context.Paint.FindAsync(id);
            _context.Paint.Remove(paint);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaintExists(decimal id)
        {
            return _context.Paint.Any(e => e.PAINTID == id);
        }
    }
}
