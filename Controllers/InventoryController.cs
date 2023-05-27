using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using guido_sanz_parcial1.Data;
using guido_sanz_parcial1.Models;
using guido_sanz_parcial1.ViewModels;
using guido_sanz_parcial1.Services;

namespace guido_sanz_parcial1.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IInventoryService _inventoryService;
        private readonly IMotoService _motoService;


        public InventoryController(IInventoryService inventoryService, IMotoService motoService)
        {
            _inventoryService = inventoryService;
            _motoService = motoService;
        }

        // GET: Inventory
        public IActionResult Index()
        {
            var inventorys = _inventoryService.GetAll();
            return inventorys != null ? 
                        View(inventorys) :
                        Problem("No se encontro ningun inventario");
        }

        // GET: Inventory/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var inventory = _inventoryService.GetById(id.Value);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // GET: Inventory/Create
        public IActionResult Create(int id)
        {            
            InventoryCreate inventoryCreate = new InventoryCreate();
            inventoryCreate.AgencyId = id;
            inventoryCreate.Motos = _motoService.GetAll().Motos;
            inventoryCreate.Inventory = new Inventory();
            return View(inventoryCreate);
        }

        // POST: Inventory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MotoId,AgencyId,Quantity")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                _inventoryService.Update(inventory);
                return RedirectToAction("Details", "Agency", new { id = inventory.AgencyId });
            }
            return View();
        }

        // GET: Inventory/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = _inventoryService.GetById(id.Value);
            if (inventory == null)
            {
                return NotFound();
            }
            return View(inventory);
        }

        // POST: Inventory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MotoId,AgencyId,Quantity")] Inventory inventory)
        {
            if (id != inventory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _inventoryService.Update(inventory);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryExists(inventory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Agency", new { id = inventory.AgencyId });
            }
            return View(inventory);
        }

        // GET: Inventory/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = _inventoryService.GetById(id.Value);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // POST: Inventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var inventory = _inventoryService.GetById(id);
            if (inventory != null)
            {
                _inventoryService.Delete(inventory);
                
            }
            return RedirectToAction("Details", "Agency", new { id = inventory.AgencyId });
        }

        private bool InventoryExists(int id)
        {
          return _inventoryService.GetById(id) != null;
        }
    }
}
