using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using stars_database.Data;
using Microsoft.AspNetCore.Authorization;
using gwiazdy.Adapters;
using stars_database.Models;

namespace stars_database.Controllers
{
    public class StarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Stars
        public async Task<IActionResult> Index()
        {
              return _context.Star != null ? 
                          View(await _context.Star.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Star'  is null.");
        }

        // GET: Stars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Star == null)
            {
                return NotFound();
            }

            var star = await _context.Star
                .FirstOrDefaultAsync(m => m.Id == id);
            if (star == null)
            {
                return NotFound();
            }
            var starDTO = StarAdapter.ConvertToDTO(star);
            return View(starDTO);
        }

        // GET: Stars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Name,Constellation,Magnitude,Distance,SpectralType,Mass,Radius,Luminosity,Description")] StarDTO starDTO)
        {
            if (ModelState.IsValid)
            {
                var star = StarAdapter.ConvertToEntity(starDTO);
                _context.Add(star);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(starDTO);
        }

        // GET: Stars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Star == null)
            {
                return NotFound();
            }

            var star = await _context.Star.FindAsync(id);
            if (star == null)
            {
                return NotFound();
            }
            var starDTO = StarAdapter.ConvertToDTO(star);
            return View(starDTO);
        }

        // POST: Stars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Constellation,Magnitude,Distance,SpectralType,Mass,Radius,Luminosity,Description")] StarDTO starDTO)
        {
            if (id != starDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var star = StarAdapter.ConvertToEntity(starDTO);
                    _context.Update(star);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StarExists(starDTO.Id))
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
            return View(starDTO);
        }

        // GET: Stars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Star == null)
            {
                return NotFound();
            }

            var star = await _context.Star
                .FirstOrDefaultAsync(m => m.Id == id);
            if (star == null)
            {
                return NotFound();
            }
            var starDTO = StarAdapter.ConvertToDTO(star);
            return View(starDTO);
        }

        // POST: Stars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Star == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Star'  is null.");
            }
            var star = await _context.Star.FindAsync(id);
            if (star != null)
            {
                _context.Star.Remove(star);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StarExists(int id)
        {
          return (_context.Star?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
