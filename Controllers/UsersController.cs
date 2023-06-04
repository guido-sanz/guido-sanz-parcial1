

using guido_sanz_parcial1.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using guido_sanz_parcial1.Services;

namespace guido_sanz_parcial1.Controllers;

[Authorize]
public class UsersController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUsersService _usersService;

    public UsersController(
        ILogger<HomeController> logger,
        IUsersService usersService)
    {
        _logger = logger;
        _usersService = usersService;
    }

    public IActionResult Index()
    {
        //listar todos los usuarios
        var users = _usersService.GetAll();
        return View(users);
    }

    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> Edit(string id)
    {
        var userViewModel = await _usersService.GetById(id);
        return View(userViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UserEditViewModel model)
    {
        _usersService.Update(model);
        return RedirectToAction("Index");
    }
}