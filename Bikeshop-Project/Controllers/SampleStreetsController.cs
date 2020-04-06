using Bikeshop_Project.Data;
using Bikeshop_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Bikeshop_Project.Controllers
{
    public class SampleStreetsController : Controller
    {
        private readonly Bikeshop_ProjectContext _context;

        public SampleStreetsController(Bikeshop_ProjectContext context)
        {
            _context = context;
        }

        // GET: SampleStreets
        public async Task<IActionResult> Index()
        {
            return View(await _context.SampleStreet.ToListAsync());
        }

        // GET: SampleStreets/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sampleStreet = await _context.SampleStreet
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sampleStreet == null)
            {
                return NotFound();
            }

            return View(sampleStreet);
        }

        // GET: SampleStreets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SampleStreets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,BASEADDRESS")] SampleStreet sampleStreet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sampleStreet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sampleStreet);
        }

        // GET: SampleStreets/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sampleStreet = await _context.SampleStreet.FindAsync(id);
            if (sampleStreet == null)
            {
                return NotFound();
            }
            return View(sampleStreet);
        }

        // POST: SampleStreets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("ID,BASEADDRESS")] SampleStreet sampleStreet)
        {
            if (id != sampleStreet.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sampleStreet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SampleStreetExists(sampleStreet.ID))
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
            return View(sampleStreet);
        }

        // GET: SampleStreets/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sampleStreet = await _context.SampleStreet
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sampleStreet == null)
            {
                return NotFound();
            }

            return View(sampleStreet);
        }

        // POST: SampleStreets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var sampleStreet = await _context.SampleStreet.FindAsync(id);
            _context.SampleStreet.Remove(sampleStreet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SampleStreetExists(decimal id)
        {
            return _context.SampleStreet.Any(e => e.ID == id);
        }
    }
}
