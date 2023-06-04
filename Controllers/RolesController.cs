using guido_sanz_parcial1.Services;
using guido_sanz_parcial1.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace guido_sanz_parcial1.Controllers;

[Authorize]
public class RolesController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IRolesService _rolesService;

    public RolesController(
        ILogger<HomeController> logger,
        IRolesService rolesService)
    {
        _logger = logger;
        _rolesService = rolesService;
    }

    public IActionResult Index()
    {
        //listar todos los roles
        var roles = _rolesService.GetAll();
        return View(roles);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(RoleCreateViewModel model)
    {
        if(string.IsNullOrEmpty(model.RoleName))
        {
            return View();
        }

        _rolesService.create(model);

        return RedirectToAction("Index");
    }
}