using guido_sanz_parcial1.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace guido_sanz_parcial1.Services;

public class RolesServiceImpl : IRolesService
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public RolesServiceImpl(RoleManager<IdentityRole> roleManager){
        _roleManager = roleManager;
    }

    public void create(RoleCreateViewModel obj)
    {
        var role = new IdentityRole(obj.RoleName);
        _roleManager.CreateAsync(role);
    }

    public List<IdentityRole> GetAll()
    {
        var roles = _roleManager.Roles.ToList();
        return roles;
    }
}