using Bikeshop_Project.Data;
using Bikeshop_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Bikeshop_Project.Controllers
{
    public class ManufacturerTransactionsController : Controller
    {
        private readonly Bikeshop_ProjectContext _context;

        public ManufacturerTransactionsController(Bikeshop_ProjectContext context)
        {
            _context = context;
        }

        // GET: ManufacturerTransactions
        public async Task<IActionResult> Index()
        {
            return View(await _context.ManufacturerTransaction.ToListAsync());
        }

        // GET: ManufacturerTransactions/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacturerTransaction = await _context.ManufacturerTransaction
                .FirstOrDefaultAsync(m => m.id == id);
            if (manufacturerTransaction == null)
            {
                return NotFound();
            }

            return View(manufacturerTransaction);
        }

        // GET: ManufacturerTransactions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ManufacturerTransactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,MANUFACTURERID,TRANSACTIONDATE,EMPLOYEEID,AMOUNT,DESCRIPTION,REFERENCE")] ManufacturerTransaction manufacturerTransaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(manufacturerTransaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(manufacturerTransaction);
        }

        // GET: ManufacturerTransactions/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacturerTransaction = await _context.ManufacturerTransaction.FindAsync(id);
            if (manufacturerTransaction == null)
            {
                return NotFound();
            }
            return View(manufacturerTransaction);
        }

        // POST: ManufacturerTransactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("id,MANUFACTURERID,TRANSACTIONDATE,EMPLOYEEID,AMOUNT,DESCRIPTION,REFERENCE")] ManufacturerTransaction manufacturerTransaction)
        {
            if (id != manufacturerTransaction.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manufacturerTransaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManufacturerTransactionExists(manufacturerTransaction.id))
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
            return View(manufacturerTransaction);
        }

        // GET: ManufacturerTransactions/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacturerTransaction = await _context.ManufacturerTransaction
                .FirstOrDefaultAsync(m => m.id == id);
            if (manufacturerTransaction == null)
            {
                return NotFound();
            }

            return View(manufacturerTransaction);
        }

        // POST: ManufacturerTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var manufacturerTransaction = await _context.ManufacturerTransaction.FindAsync(id);
            _context.ManufacturerTransaction.Remove(manufacturerTransaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManufacturerTransactionExists(decimal id)
        {
            return _context.ManufacturerTransaction.Any(e => e.id == id);
        }
    }
}
