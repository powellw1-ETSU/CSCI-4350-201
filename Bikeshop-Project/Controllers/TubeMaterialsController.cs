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
    public class TubeMaterialsController : Controller
    {
        private readonly Bikeshop_ProjectContext _context;

        public TubeMaterialsController(Bikeshop_ProjectContext context)
        {
            _context = context;
        }

        // GET: TubeMaterials
        public async Task<IActionResult> Index()
        {
            return View(await _context.TubeMaterial.ToListAsync());
        }

        // GET: TubeMaterials/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tubeMaterial = await _context.TubeMaterial
                .FirstOrDefaultAsync(m => m.TUBEID == id);
            if (tubeMaterial == null)
            {
                return NotFound();
            }

            return View(tubeMaterial);
        }

        // GET: TubeMaterials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TubeMaterials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TUBEID,MATERIAL,DESCRIPTION,DIAMETER,THICKNESS,ROUNDNESS,WEIGHT,STIFFNESS,LISTPRICE,CONSTRUCTION")] TubeMaterial tubeMaterial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tubeMaterial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tubeMaterial);
        }

        // GET: TubeMaterials/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tubeMaterial = await _context.TubeMaterial.FindAsync(id);
            if (tubeMaterial == null)
            {
                return NotFound();
            }
            return View(tubeMaterial);
        }

        // POST: TubeMaterials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("TUBEID,MATERIAL,DESCRIPTION,DIAMETER,THICKNESS,ROUNDNESS,WEIGHT,STIFFNESS,LISTPRICE,CONSTRUCTION")] TubeMaterial tubeMaterial)
        {
            if (id != tubeMaterial.TUBEID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tubeMaterial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TubeMaterialExists(tubeMaterial.TUBEID))
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
            return View(tubeMaterial);
        }

        // GET: TubeMaterials/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tubeMaterial = await _context.TubeMaterial
                .FirstOrDefaultAsync(m => m.TUBEID == id);
            if (tubeMaterial == null)
            {
                return NotFound();
            }

            return View(tubeMaterial);
        }

        // POST: TubeMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var tubeMaterial = await _context.TubeMaterial.FindAsync(id);
            _context.TubeMaterial.Remove(tubeMaterial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TubeMaterialExists(decimal id)
        {
            return _context.TubeMaterial.Any(e => e.TUBEID == id);
        }
    }
}
