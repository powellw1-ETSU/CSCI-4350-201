using Bikeshop_Project.Data;
using Bikeshop_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Bikeshop_Project.Controllers
{
    public class PurchaseItemsController : Controller
    {
        private readonly Bikeshop_ProjectContext _context;

        public PurchaseItemsController(Bikeshop_ProjectContext context)
        {
            _context = context;
        }

        // GET: PurchaseItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.PurchaseItem.ToListAsync());
        }

        // GET: PurchaseItems/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseItem = await _context.PurchaseItem
                .FirstOrDefaultAsync(m => m.id == id);
            if (purchaseItem == null)
            {
                return NotFound();
            }

            return View(purchaseItem);
        }

        // GET: PurchaseItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PurchaseItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,PURCHASEID,COMPONENTID,PRICEPAID,QUANTITY,QUANTITYRECEIVED")] PurchaseItem purchaseItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchaseItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(purchaseItem);
        }

        // GET: PurchaseItems/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseItem = await _context.PurchaseItem.FindAsync(id);
            if (purchaseItem == null)
            {
                return NotFound();
            }
            return View(purchaseItem);
        }

        // POST: PurchaseItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("id,PURCHASEID,COMPONENTID,PRICEPAID,QUANTITY,QUANTITYRECEIVED")] PurchaseItem purchaseItem)
        {
            if (id != purchaseItem.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseItemExists(purchaseItem.id))
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
            return View(purchaseItem);
        }

        // GET: PurchaseItems/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseItem = await _context.PurchaseItem
                .FirstOrDefaultAsync(m => m.id == id);
            if (purchaseItem == null)
            {
                return NotFound();
            }

            return View(purchaseItem);
        }

        // POST: PurchaseItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var purchaseItem = await _context.PurchaseItem.FindAsync(id);
            _context.PurchaseItem.Remove(purchaseItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseItemExists(decimal id)
        {
            return _context.PurchaseItem.Any(e => e.id == id);
        }
    }
}
