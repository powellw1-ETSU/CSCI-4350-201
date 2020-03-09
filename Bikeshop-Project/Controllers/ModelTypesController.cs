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
    public class ModelTypesController : Controller
    {
        private readonly Bikeshop_ProjectContext _context;

        public ModelTypesController(Bikeshop_ProjectContext context)
        {
            _context = context;
        }

        // GET: ModelTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ModelType.ToListAsync());
        }

        // GET: ModelTypes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelType = await _context.ModelType
                .FirstOrDefaultAsync(m => m.MODELTYPE == id);
            if (modelType == null)
            {
                return NotFound();
            }

            return View(modelType);
        }

        // GET: ModelTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ModelTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MODELTYPE,DESCRIPTION,COMPONENTID")] ModelType modelType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modelType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modelType);
        }

        // GET: ModelTypes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelType = await _context.ModelType.FindAsync(id);
            if (modelType == null)
            {
                return NotFound();
            }
            return View(modelType);
        }

        // POST: ModelTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MODELTYPE,DESCRIPTION,COMPONENTID")] ModelType modelType)
        {
            if (id != modelType.MODELTYPE)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelTypeExists(modelType.MODELTYPE))
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
            return View(modelType);
        }

        // GET: ModelTypes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelType = await _context.ModelType
                .FirstOrDefaultAsync(m => m.MODELTYPE == id);
            if (modelType == null)
            {
                return NotFound();
            }

            return View(modelType);
        }

        // POST: ModelTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var modelType = await _context.ModelType.FindAsync(id);
            _context.ModelType.Remove(modelType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModelTypeExists(string id)
        {
            return _context.ModelType.Any(e => e.MODELTYPE == id);
        }
    }
}
