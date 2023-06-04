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

    public IActionResult Index(string? nameFilter)
    {       
        List<IdentityRole> rolesList;
        if(!string.IsNullOrEmpty(nameFilter)){
                rolesList = _rolesService.GetAll(nameFilter);
            }else{
                rolesList = _rolesService.GetAll();
        }
        var rolesSearchViewModel = new RolesSearchViewModel();
        rolesSearchViewModel.Roles = rolesList;
        return View(rolesSearchViewModel);
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