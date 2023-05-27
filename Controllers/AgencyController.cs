using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using guido_sanz_parcial1.Models;
using guido_sanz_parcial1.ViewModels;
using guido_sanz_parcial1.Services;

namespace guido_sanz_parcial1.Controllers
{
    public class AgencyController : Controller
    {
        private readonly IAgencyService _agencyService;

        public AgencyController(IAgencyService agencyService)
        {
            _agencyService = agencyService;
        }

        // GET: Agency
        public IActionResult Index(string? nameFilter)
        {
            AgencyViewModel agencys;

            if(!string.IsNullOrEmpty(nameFilter)){
                agencys = _agencyService.GetAll(nameFilter);
            }else{
                agencys = _agencyService.GetAll();
            }

            return agencys != null ? 
                        View(agencys) :
                        Problem("Entity set 'AgencyContext.Agency'  is null.");
                          
        }

        // GET: Agency/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agency = _agencyService.GetAgencyWithInventoryById(id.Value);
                
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
                _agencyService.Update(agency);
                return RedirectToAction(nameof(Index));
            }
            return View(agency);
        }

        // GET: Agency/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agency = _agencyService.GetById(id.Value);
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
                    _agencyService.Update(agency);
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
            if (id == null)
            {
                return NotFound();
            }

            var agency = _agencyService.GetById(id.Value);
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
            var agency = _agencyService.GetAgencyWithInventoryById(id);
            if (agency != null)
            {
                _agencyService.Delete(agency);               
            }
            return RedirectToAction(nameof(Index));
        }

        private bool AgencyExists(int id)
        {
          return _agencyService.GetById(id) != null;
        }
    }
}
