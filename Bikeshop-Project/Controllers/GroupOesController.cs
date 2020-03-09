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
    public class GroupOesController : Controller
    {
        private readonly Bikeshop_ProjectContext _context;

        public GroupOesController(Bikeshop_ProjectContext context)
        {
            _context = context;
        }

        // GET: GroupOes
        public async Task<IActionResult> Index()
        {
            return View(await _context.GroupO.ToListAsync());
        }

        // GET: GroupOes/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupO = await _context.GroupO
                .FirstOrDefaultAsync(m => m.COMPONENTGROUPID == id);
            if (groupO == null)
            {
                return NotFound();
            }

            return View(groupO);
        }

        // GET: GroupOes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GroupOes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("COMPONENTGROUPID,GROUPNAME,BIKETYPE,YEAR,ENDYEAR,WEIGHT")] GroupO groupO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(groupO);
        }

        // GET: GroupOes/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupO = await _context.GroupO.FindAsync(id);
            if (groupO == null)
            {
                return NotFound();
            }
            return View(groupO);
        }

        // POST: GroupOes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("COMPONENTGROUPID,GROUPNAME,BIKETYPE,YEAR,ENDYEAR,WEIGHT")] GroupO groupO)
        {
            if (id != groupO.COMPONENTGROUPID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupOExists(groupO.COMPONENTGROUPID))
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
            return View(groupO);
        }

        // GET: GroupOes/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupO = await _context.GroupO
                .FirstOrDefaultAsync(m => m.COMPONENTGROUPID == id);
            if (groupO == null)
            {
                return NotFound();
            }

            return View(groupO);
        }

        // POST: GroupOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var groupO = await _context.GroupO.FindAsync(id);
            _context.GroupO.Remove(groupO);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupOExists(decimal id)
        {
            return _context.GroupO.Any(e => e.COMPONENTGROUPID == id);
        }
    }
}
