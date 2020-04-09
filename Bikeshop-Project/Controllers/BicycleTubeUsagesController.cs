using Bikeshop_Project.Data;
using Bikeshop_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Bikeshop_Project.Controllers
{
    public class BicycleTubeUsagesController : Controller
    {
        private readonly Bikeshop_ProjectContext _context;

        public BicycleTubeUsagesController(Bikeshop_ProjectContext context)
        {
            _context = context;
        }

        // GET: BicycleTubeUsages
        public async Task<IActionResult> Index()
        {
            return View(await _context.BicycleTubeUsage.ToListAsync());
        }

        // GET: BicycleTubeUsages/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicycleTubeUsage = await _context.BicycleTubeUsage
                .FirstOrDefaultAsync(m => m.id == id);
            if (bicycleTubeUsage == null)
            {
                return NotFound();
            }

            return View(bicycleTubeUsage);
        }

        // GET: BicycleTubeUsages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BicycleTubeUsages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SERIALNUMBER,TUBEID,QUANTITY,id")] BicycleTubeUsage bicycleTubeUsage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bicycleTubeUsage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bicycleTubeUsage);
        }

        // GET: BicycleTubeUsages/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicycleTubeUsage = await _context.BicycleTubeUsage.FindAsync(id);
            if (bicycleTubeUsage == null)
            {
                return NotFound();
            }
            return View(bicycleTubeUsage);
        }

        // POST: BicycleTubeUsages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("SERIALNUMBER,TUBEID,QUANTITY,id")] BicycleTubeUsage bicycleTubeUsage)
        {
            if (id != bicycleTubeUsage.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bicycleTubeUsage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BicycleTubeUsageExists(bicycleTubeUsage.id))
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
            return View(bicycleTubeUsage);
        }

        // GET: BicycleTubeUsages/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicycleTubeUsage = await _context.BicycleTubeUsage
                .FirstOrDefaultAsync(m => m.id == id);
            if (bicycleTubeUsage == null)
            {
                return NotFound();
            }

            return View(bicycleTubeUsage);
        }

        // POST: BicycleTubeUsages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var bicycleTubeUsage = await _context.BicycleTubeUsage.FindAsync(id);
            _context.BicycleTubeUsage.Remove(bicycleTubeUsage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BicycleTubeUsageExists(decimal id)
        {
            return _context.BicycleTubeUsage.Any(e => e.id == id);
        }
    }
}
