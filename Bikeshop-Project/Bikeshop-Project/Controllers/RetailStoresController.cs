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
    public class RetailStoresController : Controller
    {
        private readonly Bikeshop_ProjectContext _context;

        public RetailStoresController(Bikeshop_ProjectContext context)
        {
            _context = context;
        }

        // GET: RetailStores
        public async Task<IActionResult> Index()
        {
            return View(await _context.RetailStore.ToListAsync());
        }

        // GET: RetailStores/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retailStore = await _context.RetailStore
                .FirstOrDefaultAsync(m => m.STOREID == id);
            if (retailStore == null)
            {
                return NotFound();
            }

            return View(retailStore);
        }

        // GET: RetailStores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RetailStores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("STOREID,STORENAME,PHONE,CONTACTFIRSTNAME,CONTACTLASTNAME,ADDRESS,ZIPCODE,CITYID")] RetailStore retailStore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(retailStore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(retailStore);
        }

        // GET: RetailStores/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retailStore = await _context.RetailStore.FindAsync(id);
            if (retailStore == null)
            {
                return NotFound();
            }
            return View(retailStore);
        }

        // POST: RetailStores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("STOREID,STORENAME,PHONE,CONTACTFIRSTNAME,CONTACTLASTNAME,ADDRESS,ZIPCODE,CITYID")] RetailStore retailStore)
        {
            if (id != retailStore.STOREID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(retailStore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RetailStoreExists(retailStore.STOREID))
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
            return View(retailStore);
        }

        // GET: RetailStores/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retailStore = await _context.RetailStore
                .FirstOrDefaultAsync(m => m.STOREID == id);
            if (retailStore == null)
            {
                return NotFound();
            }

            return View(retailStore);
        }

        // POST: RetailStores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var retailStore = await _context.RetailStore.FindAsync(id);
            _context.RetailStore.Remove(retailStore);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RetailStoreExists(decimal id)
        {
            return _context.RetailStore.Any(e => e.STOREID == id);
        }
    }
}
