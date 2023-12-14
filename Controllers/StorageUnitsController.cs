using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PackitupStoragePark.Data;

namespace PackitupStoragePark.Controllers
{
    public class StorageUnitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StorageUnitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StorageUnits
        public async Task<IActionResult> Index()
        {
              return _context.StorageUnits != null ? 
                          View(await _context.StorageUnits.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.StorageUnits'  is null.");
        }

        // GET: StorageUnits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StorageUnits == null)
            {
                return NotFound();
            }

            var storageUnit = await _context.StorageUnits
                .FirstOrDefaultAsync(m => m.UnitId == id);
            if (storageUnit == null)
            {
                return NotFound();
            }

            return View(storageUnit);
        }

        // GET: StorageUnits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StorageUnits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UnitId,UnitSize,UnitNumber,UniPrince")] StorageUnit storageUnit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storageUnit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(storageUnit);
        }

        // GET: StorageUnits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StorageUnits == null)
            {
                return NotFound();
            }

            var storageUnit = await _context.StorageUnits.FindAsync(id);
            if (storageUnit == null)
            {
                return NotFound();
            }
            return View(storageUnit);
        }

        // POST: StorageUnits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UnitId,UnitSize,UnitNumber,UniPrince")] StorageUnit storageUnit)
        {
            if (id != storageUnit.UnitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storageUnit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StorageUnitExists(storageUnit.UnitId))
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
            return View(storageUnit);
        }

        // GET: StorageUnits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StorageUnits == null)
            {
                return NotFound();
            }

            var storageUnit = await _context.StorageUnits
                .FirstOrDefaultAsync(m => m.UnitId == id);
            if (storageUnit == null)
            {
                return NotFound();
            }

            return View(storageUnit);
        }

        // POST: StorageUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StorageUnits == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StorageUnits'  is null.");
            }
            var storageUnit = await _context.StorageUnits.FindAsync(id);
            if (storageUnit != null)
            {
                _context.StorageUnits.Remove(storageUnit);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StorageUnitExists(int id)
        {
          return (_context.StorageUnits?.Any(e => e.UnitId == id)).GetValueOrDefault();
        }
    }
}
