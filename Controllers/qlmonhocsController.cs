using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAsp.Data;
using WebAsp.Models;

namespace WebAsp.Controllers
{
    public class qlmonhocsController : Controller
    {
        private readonly WebDbContext _context;

        public qlmonhocsController(WebDbContext context)
        {
            _context = context;
        }

        // GET: qlmonhocs
        public async Task<IActionResult> Index()
        {
            return View(await _context.qlmonhoc.ToListAsync());
        }

        // GET: qlmonhocs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qlmonhoc = await _context.qlmonhoc
                .FirstOrDefaultAsync(m => m.MAMH == id);
            if (qlmonhoc == null)
            {
                return NotFound();
            }

            return View(qlmonhoc);
        }

        // GET: qlmonhocs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: qlmonhocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MAMH,TENMH,SOTINCHI")] qlmonhoc qlmonhoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qlmonhoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(qlmonhoc);
        }

        // GET: qlmonhocs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qlmonhoc = await _context.qlmonhoc.FindAsync(id);
            if (qlmonhoc == null)
            {
                return NotFound();
            }
            return View(qlmonhoc);
        }

        // POST: qlmonhocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MAMH,TENMH,SOTINCHI")] qlmonhoc qlmonhoc)
        {
            if (id != qlmonhoc.MAMH)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qlmonhoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!qlmonhocExists(qlmonhoc.MAMH))
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
            return View(qlmonhoc);
        }

        // GET: qlmonhocs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qlmonhoc = await _context.qlmonhoc
                .FirstOrDefaultAsync(m => m.MAMH == id);
            if (qlmonhoc == null)
            {
                return NotFound();
            }

            return View(qlmonhoc);
        }

        // POST: qlmonhocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var qlmonhoc = await _context.qlmonhoc.FindAsync(id);
            if (qlmonhoc != null)
            {
                _context.qlmonhoc.Remove(qlmonhoc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool qlmonhocExists(int id)
        {
            return _context.qlmonhoc.Any(e => e.MAMH == id);
        }
    }
}
