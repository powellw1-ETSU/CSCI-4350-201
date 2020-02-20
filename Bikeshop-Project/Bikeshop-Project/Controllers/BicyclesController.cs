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
    public class BicyclesController : Controller
    {
        private readonly Bikeshop_ProjectContext _context;

        public BicyclesController(Bikeshop_ProjectContext context)
        {
            _context = context;
        }

        // GET: Bicycles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bicycle.ToListAsync());
        }

        // GET: Bicycles/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicycle = await _context.Bicycle
                .FirstOrDefaultAsync(m => m.SERIALNUMBER == id);
            if (bicycle == null)
            {
                return NotFound();
            }

            return View(bicycle);
        }

        // GET: Bicycles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bicycles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SERIALNUMBER,CUSTOMERID,MODELTYPE,PAINTID,FRAMESIZE,ORDERDATE,STARTDATE,SHIPDATE,SHIPEMPLOYEE,FRAMEASSEMBLER,PAINTER,CONSTRUCTION,WATERBOTTLEBRAZEONS,CUSTOMNAME,LETTERSTYLEID,STOREID,EMPLOYEEID,TOPTUBE,CHAINSTAY,HEADTUBEANGLE,SEATTUBEANGLE,LISTPRICE,SALEPRICE,SALESTAX,SALESTATE,SHIPPRICE,FRAMEPRICE,COMPONENTLIST")] Bicycle bicycle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bicycle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bicycle);
        }

        // GET: Bicycles/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicycle = await _context.Bicycle.FindAsync(id);
            if (bicycle == null)
            {
                return NotFound();
            }
            return View(bicycle);
        }

        // POST: Bicycles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("SERIALNUMBER,CUSTOMERID,MODELTYPE,PAINTID,FRAMESIZE,ORDERDATE,STARTDATE,SHIPDATE,SHIPEMPLOYEE,FRAMEASSEMBLER,PAINTER,CONSTRUCTION,WATERBOTTLEBRAZEONS,CUSTOMNAME,LETTERSTYLEID,STOREID,EMPLOYEEID,TOPTUBE,CHAINSTAY,HEADTUBEANGLE,SEATTUBEANGLE,LISTPRICE,SALEPRICE,SALESTAX,SALESTATE,SHIPPRICE,FRAMEPRICE,COMPONENTLIST")] Bicycle bicycle)
        {
            if (id != bicycle.SERIALNUMBER)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bicycle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BicycleExists(bicycle.SERIALNUMBER))
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
            return View(bicycle);
        }

        // GET: Bicycles/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicycle = await _context.Bicycle
                .FirstOrDefaultAsync(m => m.SERIALNUMBER == id);
            if (bicycle == null)
            {
                return NotFound();
            }

            return View(bicycle);
        }

        // POST: Bicycles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var bicycle = await _context.Bicycle.FindAsync(id);
            _context.Bicycle.Remove(bicycle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BicycleExists(decimal id)
        {
            return _context.Bicycle.Any(e => e.SERIALNUMBER == id);
        }
    }
}
