using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using guido_sanz_parcial1.Models;
using guido_sanz_parcial1.ViewModels;
using guido_sanz_parcial1.Services;
using Microsoft.AspNetCore.Authorization;

namespace guido_sanz_parcial1.Controllers
{
    [Authorize]
    public class MotoController : Controller
    {

        private readonly IMotoService _motoService;
        private readonly IAccesoryService _accesoryService;

        public MotoController(IMotoService motoService, IAccesoryService accesoryService)
        {
            _motoService = motoService;
            _accesoryService = accesoryService;
        }

        // GET: Moto
        public IActionResult Index(string? nameFilter)
        {
            MotoViewModel motos;

            if(!string.IsNullOrEmpty(nameFilter)){
                motos = _motoService.GetAll(nameFilter);
            }else{
                motos = _motoService.GetAll();
            }

            return motos != null ? 
                        View(motos) :
                        Problem("Entity set 'MvcMotoContext.Moto'  is null.");
        }

        // GET: Moto/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moto = _motoService.GetById(id.Value);

            if (moto == null)
            {
                return NotFound();
            }

            return View(moto);
        }

        // GET: Moto/Create
        public IActionResult Create()
        {
            MotoCreateViewModel model = new MotoCreateViewModel();
            var accesories = _accesoryService.GetAll();
            model.Accesories = accesories.Accesories;
            return View(model);
        }

        // POST: Moto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MotoCreateViewModel model)
        {           
            if (ModelState.IsValid)
            {
                bool existMoto = _motoService.ExistMotoWithBrandAndName(model.Moto.Brand, model.Moto.Model);
                if(!existMoto){
                    _motoService.Update(model);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ErrorMessage"] = "¡La moto ya existe!";
                }              
            }
            return View(model.Moto);
        }

        // GET: Moto/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moto =  _motoService.GetById(id.Value);
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
        public async Task<IActionResult> Edit(int id, MotoCreateViewModel model)
        {
            if (id != model.Moto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _motoService.Update(model);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotoExists(model.Moto.Id))
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
            return View(model.Moto);
        }

        // GET: Moto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moto = _motoService.GetById(id.Value);
            if (moto == null)
            {
                return NotFound();
            }

            return View(moto);
        }

        // POST: Moto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var moto = _motoService.GetById(id);
            if (moto != null)
            {
                _motoService.Delete(moto);
            }
            
            
            return RedirectToAction(nameof(Index));
        }

        private bool MotoExists(int id)
        {
          return _motoService.GetById(id) != null;
        }
    }
}
