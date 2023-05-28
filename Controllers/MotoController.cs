using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using guido_sanz_parcial1.Models;
using guido_sanz_parcial1.ViewModels;
using guido_sanz_parcial1.Services;

namespace guido_sanz_parcial1.Controllers
{
    public class MotoController : Controller
    {

        private readonly IMotoService _motoService;

        public MotoController(IMotoService motoService)
        {
            _motoService = motoService;
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
            return View();
        }

        // POST: Moto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Brand,Model,CubicCentimeters,Type,Price")] Moto moto)
        {           
            if (ModelState.IsValid)
            {
                bool existMoto = _motoService.ExistMotoWithBrandAndName(moto.Brand, moto.Model);
                if(!existMoto){
                    _motoService.Update(moto);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ErrorMessage"] = "¡La moto ya existe!";
                }              
            }
            return View(moto);
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
                    _motoService.Update(moto);
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
