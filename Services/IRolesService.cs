namespace guido_sanz_parcial1.Services;

using guido_sanz_parcial1.ViewModels;
using Microsoft.AspNetCore.Identity;

public interface IRolesService
{
    List<IdentityRole> GetAll();
    
    List<IdentityRole> GetAll(string namefilter);
    void create(RoleCreateViewModel obj);
}