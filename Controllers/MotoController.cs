using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using guido_sanz_parcial1.Data;
using guido_sanz_parcial1.Models;
using guido_sanz_parcial1.ViewModels;

namespace guido_sanz_parcial1.Controllers
{
    public class MotoController : Controller
    {
        private readonly MotoContext _context;

        public MotoController(MotoContext context)
        {
            _context = context;
        }

        // GET: Moto
        public async Task<IActionResult> Index(string? nameFilter)
        {
            var query = from moto in _context.Moto select moto;
            if(!string.IsNullOrEmpty(nameFilter)){
                query = query.Where(x => x.Brand.ToLower().Contains(nameFilter.ToLower()));
            }

            MotoViewModel motos = new MotoViewModel();
            motos.Motos = await query.ToListAsync();

            return _context.Moto != null ? 
                        View(motos) :
                        Problem("Entity set 'MvcMotoContext.Moto'  is null.");
        }

        // GET: Moto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Moto == null)
            {
                return NotFound();
            }

            var moto = await _context.Moto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moto == null)
            {
                return NotFound();
            }

            return View(moto);
        }

        // GET: Moto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Moto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brand,Model,CubicCentimeters,Type,Price")] Moto moto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(moto);
        }

        // GET: Moto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Moto == null)
            {
                return NotFound();
            }

            var moto = await _context.Moto.FindAsync(id);
            if (moto == null)
            {
                return NotFound();
            }
            return View(moto);
        }

        // POST: Moto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,Model,CubicCentimeters,Type,Price")] Moto moto)
        {
            if (id != moto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotoExists(moto.Id))
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
            return View(moto);
        }

        // GET: Moto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Moto == null)
            {
                return NotFound();
            }

            var moto = await _context.Moto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moto == null)
            {
                return NotFound();
            }

            return View(moto);
        }

        // POST: Moto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Moto == null)
            {
                return Problem("Entity set 'MvcMotoContext.Moto'  is null.");
            }
            var moto = await _context.Moto.FindAsync(id);
            if (moto != null)
            {
                _context.Moto.Remove(moto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotoExists(int id)
        {
          return (_context.Moto?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
