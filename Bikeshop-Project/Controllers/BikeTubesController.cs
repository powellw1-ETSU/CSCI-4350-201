using Bikeshop_Project.Data;
using Bikeshop_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Bikeshop_Project.Controllers
{
    public class BikeTubesController : Controller
    {
        private readonly Bikeshop_ProjectContext _context;

        public BikeTubesController(Bikeshop_ProjectContext context)
        {
            _context = context;
        }

        // GET: BikeTubes
        public async Task<IActionResult> Index()
        {
            return View(await _context.BikeTubes.ToListAsync());
        }

        // GET: BikeTubes/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bikeTubes = await _context.BikeTubes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bikeTubes == null)
            {
                return NotFound();
            }

            return View(bikeTubes);
        }

        // GET: BikeTubes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BikeTubes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,SERIALNUMBER,TUBENAME,TUBEID,LENGTH")] BikeTubes bikeTubes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bikeTubes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bikeTubes);
        }

        // GET: BikeTubes/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bikeTubes = await _context.BikeTubes.FindAsync(id);
            if (bikeTubes == null)
            {
                return NotFound();
            }
            return View(bikeTubes);
        }

        // POST: BikeTubes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("ID,SERIALNUMBER,TUBENAME,TUBEID,LENGTH")] BikeTubes bikeTubes)
        {
            if (id != bikeTubes.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bikeTubes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BikeTubesExists(bikeTubes.ID))
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
            return View(bikeTubes);
        }

        // GET: BikeTubes/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bikeTubes = await _context.BikeTubes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bikeTubes == null)
            {
                return NotFound();
            }

            return View(bikeTubes);
        }

        // POST: BikeTubes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var bikeTubes = await _context.BikeTubes.FindAsync(id);
            _context.BikeTubes.Remove(bikeTubes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BikeTubesExists(decimal id)
        {
            return _context.BikeTubes.Any(e => e.ID == id);
        }
    }
}
