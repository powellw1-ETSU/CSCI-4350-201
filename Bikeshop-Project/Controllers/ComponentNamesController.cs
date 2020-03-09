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
    public class ComponentNamesController : Controller
    {
        private readonly Bikeshop_ProjectContext _context;

        public ComponentNamesController(Bikeshop_ProjectContext context)
        {
            _context = context;
        }

        // GET: ComponentNames
        public async Task<IActionResult> Index()
        {
            return View(await _context.ComponentName.ToListAsync());
        }

        // GET: ComponentNames/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componentName = await _context.ComponentName
                .FirstOrDefaultAsync(m => m.COMPONENTNAME == id);
            if (componentName == null)
            {
                return NotFound();
            }

            return View(componentName);
        }

        // GET: ComponentNames/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ComponentNames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("COMPONENTNAME,ASSEMBLYORDER,DESCRIPTION")] ComponentName componentName)
        {
            if (ModelState.IsValid)
            {
                _context.Add(componentName);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(componentName);
        }

        // GET: ComponentNames/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componentName = await _context.ComponentName.FindAsync(id);
            if (componentName == null)
            {
                return NotFound();
            }
            return View(componentName);
        }

        // POST: ComponentNames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("COMPONENTNAME,ASSEMBLYORDER,DESCRIPTION")] ComponentName componentName)
        {
            if (id != componentName.COMPONENTNAME)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(componentName);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComponentNameExists(componentName.COMPONENTNAME))
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
            return View(componentName);
        }

        // GET: ComponentNames/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componentName = await _context.ComponentName
                .FirstOrDefaultAsync(m => m.COMPONENTNAME == id);
            if (componentName == null)
            {
                return NotFound();
            }

            return View(componentName);
        }

        // POST: ComponentNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var componentName = await _context.ComponentName.FindAsync(id);
            _context.ComponentName.Remove(componentName);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComponentNameExists(string id)
        {
            return _context.ComponentName.Any(e => e.COMPONENTNAME == id);
        }
    }
}
