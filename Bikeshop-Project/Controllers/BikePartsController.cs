using Bikeshop_Project.Data;
using Bikeshop_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Bikeshop_Project.Controllers
{
    public class BikePartsController : Controller
    {
        private readonly Bikeshop_ProjectContext _context;

        public BikePartsController(Bikeshop_ProjectContext context)
        {
            _context = context;
        }

        // GET: BikeParts
        public async Task<IActionResult> Index()
        {
            return View(await _context.BikeParts.ToListAsync());
        }

        // GET: BikeParts/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bikeParts = await _context.BikeParts
                .FirstOrDefaultAsync(m => m.id == id);
            if (bikeParts == null)
            {
                return NotFound();
            }

            return View(bikeParts);
        }

        // GET: BikeParts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BikeParts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SERIALNUMBER,COMPONENTID,SUBSTITUTEID,LOCATION,QUANTITY,DATEINSTALLED,EMPLOYEEID,id")] BikeParts bikeParts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bikeParts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bikeParts);
        }

        // GET: BikeParts/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bikeParts = await _context.BikeParts.FindAsync(id);
            if (bikeParts == null)
            {
                return NotFound();
            }
            return View(bikeParts);
        }

        // POST: BikeParts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("SERIALNUMBER,COMPONENTID,SUBSTITUTEID,LOCATION,QUANTITY,DATEINSTALLED,EMPLOYEEID,id")] BikeParts bikeParts)
        {
            if (id != bikeParts.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bikeParts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BikePartsExists(bikeParts.id))
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
            return View(bikeParts);
        }

        // GET: BikeParts/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bikeParts = await _context.BikeParts
                .FirstOrDefaultAsync(m => m.id == id);
            if (bikeParts == null)
            {
                return NotFound();
            }

            return View(bikeParts);
        }

        // POST: BikeParts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var bikeParts = await _context.BikeParts.FindAsync(id);
            _context.BikeParts.Remove(bikeParts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BikePartsExists(decimal id)
        {
            return _context.BikeParts.Any(e => e.id == id);
        }
    }
}
