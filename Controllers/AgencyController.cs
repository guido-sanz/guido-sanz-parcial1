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
    public class AgencyController : Controller
    {
        private readonly MotoContext _context;

        public AgencyController(MotoContext context)
        {
            _context = context;
        }

        // GET: Agency
        public async Task<IActionResult> Index(string? nameFilter)
        {
            var query = from agency in _context.Agency select agency;
            if(!string.IsNullOrEmpty(nameFilter)){
                query = query.Where(x => x.Name.ToLower().Contains(nameFilter.ToLower()));
            }

            AgencyViewModel agencys = new AgencyViewModel();
            agencys.Agencys = await query.ToListAsync();

              return _context.Agency != null ? 
                          View(agencys) :
                          Problem("Entity set 'AgencyContext.Agency'  is null.");
                          
        }

        // GET: Agency/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Agency == null)
            {
                return NotFound();
            }

            var agency = await _context.Agency.Include(x=> x.Invertorys).ThenInclude(i => i.Moto)
                .FirstOrDefaultAsync(m => m.Id == id);
                
            if (agency == null)
            {
                return NotFound();
            }

            return View(agency);
        }

        // GET: Agency/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Agency/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,Phone")] Agency agency)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agency);
        }

        // GET: Agency/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Agency == null)
            {
                return NotFound();
            }

            var agency = await _context.Agency.FindAsync(id);
            if (agency == null)
            {
                return NotFound();
            }
            return View(agency);
        }

        // POST: Agency/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,Phone")] Agency agency)
        {
            if (id != agency.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgencyExists(agency.Id))
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
            return View(agency);
        }

        // GET: Agency/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Agency == null)
            {
                return NotFound();
            }

            var agency = await _context.Agency
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agency == null)
            {
                return NotFound();
            }

            return View(agency);
        }

        // POST: Agency/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Agency == null)
            {
                return Problem("Entity set 'MvcAgencyContext.Agency'  is null.");
            }
            var agency = await _context.Agency.Include(x=> x.Invertorys).ThenInclude(i => i.Moto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agency != null)
            {

                _context.Inventory.RemoveRange(agency.Invertorys);
                _context.Agency.Remove(agency);
            }
             
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgencyExists(int id)
        {
          return (_context.Agency?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
