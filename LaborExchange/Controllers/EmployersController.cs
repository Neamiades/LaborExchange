using System.Linq;
using System.Threading.Tasks;
using LaborExchange.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaborExchange.Models.Entities;

namespace LaborExchange.Controllers
{
    public class EmployersController : Controller
    {
        private readonly LaborExchangeContext _context;

        public EmployersController(LaborExchangeContext context)
        {
            _context = context;
        }

        // GET: Employers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employers.ToListAsync());
        }

        // GET: Employers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employers = await _context.Employers
                .SingleOrDefaultAsync(m => m.Id == id);
            if (employers == null)
            {
                return NotFound();
            }

            return View(employers);
        }

        // GET: Employers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Status,Name,Contacts")] Employers employers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employers);
        }

        // GET: Employers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employers = await _context.Employers.SingleOrDefaultAsync(m => m.Id == id);
            if (employers == null)
            {
                return NotFound();
            }
            return View(employers);
        }

        // POST: Employers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Status,Name,Contacts")] Employers employers)
        {
            if (id != employers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployersExists(employers.Id))
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
            return View(employers);
        }

        // GET: Employers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employers = await _context.Employers
                .SingleOrDefaultAsync(m => m.Id == id);
            if (employers == null)
            {
                return NotFound();
            }

            return View(employers);
        }

        // POST: Employers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employers = await _context.Employers.SingleOrDefaultAsync(m => m.Id == id);
            _context.Employers.Remove(employers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployersExists(int id)
        {
            return _context.Employers.Any(e => e.Id == id);
        }
    }
}
