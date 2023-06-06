using guido_sanz_parcial1.Models;
using guido_sanz_parcial1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace guido_sanz_parcial1.Controllers;

public class AccesoryController : Controller
{
    private readonly IAccesoryService _accesoryService;

    public AccesoryController(IAccesoryService accesoryService){
        _accesoryService = accesoryService;
    }

    [Authorize(Roles = "admin")]
    public IActionResult Index(string? nameFilter)
    {       
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create([Bind("Id,Name,SerialNumber")]Accesory model)
    {
        if (ModelState.IsValid)
        {
            _accesoryService.Update(model);
            return RedirectToAction(nameof(Index));
        }

        return RedirectToAction("Index");
    }
}