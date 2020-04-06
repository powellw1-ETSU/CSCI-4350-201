using Bikeshop_Project.Data;
using Bikeshop_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Bikeshop_Project.Controllers
{
    public class CustomerTransactionsController : Controller
    {
        private readonly Bikeshop_ProjectContext _context;

        public CustomerTransactionsController(Bikeshop_ProjectContext context)
        {
            _context = context;
        }

        // GET: CustomerTransactions
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomerTransaction.ToListAsync());
        }

        // GET: CustomerTransactions/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerTransaction = await _context.CustomerTransaction
                .FirstOrDefaultAsync(m => m.id == id);
            if (customerTransaction == null)
            {
                return NotFound();
            }

            return View(customerTransaction);
        }

        // GET: CustomerTransactions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerTransactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CUSTOMERID,TRANSACTIONDATE,EMPLOYEEID,AMOUNT,DESCRIPTION,REFERENCE,id")] CustomerTransaction customerTransaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerTransaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerTransaction);
        }

        // GET: CustomerTransactions/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerTransaction = await _context.CustomerTransaction.FindAsync(id);
            if (customerTransaction == null)
            {
                return NotFound();
            }
            return View(customerTransaction);
        }

        // POST: CustomerTransactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("CUSTOMERID,TRANSACTIONDATE,EMPLOYEEID,AMOUNT,DESCRIPTION,REFERENCE,id")] CustomerTransaction customerTransaction)
        {
            if (id != customerTransaction.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerTransaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerTransactionExists(customerTransaction.id))
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
            return View(customerTransaction);
        }

        // GET: CustomerTransactions/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerTransaction = await _context.CustomerTransaction
                .FirstOrDefaultAsync(m => m.id == id);
            if (customerTransaction == null)
            {
                return NotFound();
            }

            return View(customerTransaction);
        }

        // POST: CustomerTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var customerTransaction = await _context.CustomerTransaction.FindAsync(id);
            _context.CustomerTransaction.Remove(customerTransaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerTransactionExists(decimal id)
        {
            return _context.CustomerTransaction.Any(e => e.id == id);
        }
    }
}
