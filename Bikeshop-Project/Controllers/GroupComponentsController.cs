using Bikeshop_Project.Data;
using Bikeshop_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Bikeshop_Project.Controllers
{
    public class GroupComponentsController : Controller
    {
        private readonly Bikeshop_ProjectContext _context;

        public GroupComponentsController(Bikeshop_ProjectContext context)
        {
            _context = context;
        }

        // GET: GroupComponents
        public async Task<IActionResult> Index()
        {
            return View(await _context.GroupComponents.ToListAsync());
        }

        // GET: GroupComponents/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupComponents = await _context.GroupComponents
                .FirstOrDefaultAsync(m => m.id == id);
            if (groupComponents == null)
            {
                return NotFound();
            }

            return View(groupComponents);
        }

        // GET: GroupComponents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GroupComponents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GROUPID,COMPONENTID,id")] GroupComponents groupComponents)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupComponents);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(groupComponents);
        }

        // GET: GroupComponents/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupComponents = await _context.GroupComponents.FindAsync(id);
            if (groupComponents == null)
            {
                return NotFound();
            }
            return View(groupComponents);
        }

        // POST: GroupComponents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("GROUPID,COMPONENTID,id")] GroupComponents groupComponents)
        {
            if (id != groupComponents.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupComponents);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupComponentsExists(groupComponents.id))
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
            return View(groupComponents);
        }

        // GET: GroupComponents/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupComponents = await _context.GroupComponents
                .FirstOrDefaultAsync(m => m.id == id);
            if (groupComponents == null)
            {
                return NotFound();
            }

            return View(groupComponents);
        }

        // POST: GroupComponents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var groupComponents = await _context.GroupComponents.FindAsync(id);
            _context.GroupComponents.Remove(groupComponents);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupComponentsExists(decimal id)
        {
            return _context.GroupComponents.Any(e => e.id == id);
        }
    }
}
