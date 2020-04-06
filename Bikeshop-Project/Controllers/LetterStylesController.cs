using Bikeshop_Project.Data;
using Bikeshop_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Bikeshop_Project.Controllers
{
    public class LetterStylesController : Controller
    {
        private readonly Bikeshop_ProjectContext _context;

        public LetterStylesController(Bikeshop_ProjectContext context)
        {
            _context = context;
        }

        // GET: LetterStyles
        public async Task<IActionResult> Index()
        {
            return View(await _context.LetterStyle.ToListAsync());
        }

        // GET: LetterStyles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var letterStyle = await _context.LetterStyle
                .FirstOrDefaultAsync(m => m.LETTERSTYLE == id);
            if (letterStyle == null)
            {
                return NotFound();
            }

            return View(letterStyle);
        }

        // GET: LetterStyles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LetterStyles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LETTERSTYLE,DESCRIPTION")] LetterStyle letterStyle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(letterStyle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(letterStyle);
        }

        // GET: LetterStyles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var letterStyle = await _context.LetterStyle.FindAsync(id);
            if (letterStyle == null)
            {
                return NotFound();
            }
            return View(letterStyle);
        }

        // POST: LetterStyles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("LETTERSTYLE,DESCRIPTION")] LetterStyle letterStyle)
        {
            if (id != letterStyle.LETTERSTYLE)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(letterStyle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LetterStyleExists(letterStyle.LETTERSTYLE))
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
            return View(letterStyle);
        }

        // GET: LetterStyles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var letterStyle = await _context.LetterStyle
                .FirstOrDefaultAsync(m => m.LETTERSTYLE == id);
            if (letterStyle == null)
            {
                return NotFound();
            }

            return View(letterStyle);
        }

        // POST: LetterStyles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var letterStyle = await _context.LetterStyle.FindAsync(id);
            _context.LetterStyle.Remove(letterStyle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LetterStyleExists(string id)
        {
            return _context.LetterStyle.Any(e => e.LETTERSTYLE == id);
        }
    }
}
