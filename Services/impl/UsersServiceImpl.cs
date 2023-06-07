using guido_sanz_parcial1.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace guido_sanz_parcial1.Services;

public class UsersServiceImpl : IUsersService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UsersServiceImpl(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager){
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public void Delete(UserEditViewModel obj)
    {
        throw new NotImplementedException();
    }

    public List<IdentityUser> GetAll()
    {
       return _userManager.Users.ToList();
    }

    public List<IdentityUser> GetAll(string usernameFilter)
    {
        return _userManager.Users.Where(x => x.UserName.ToLower().Contains(usernameFilter.ToLower()) || x.Email.ToLower().Contains(usernameFilter.ToLower())).ToList();
    }

    public async Task<UserEditViewModel?> GetById(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        var userViewModel = new UserEditViewModel();
        userViewModel.UserName = user.UserName ?? string.Empty;
        userViewModel.Email = user.Email ?? string.Empty;
        userViewModel.Roles = new SelectList(_roleManager.Roles.ToList());

        return userViewModel;
    }

    public async void Update(UserEditViewModel obj)
    {
        var user = await _userManager.FindByNameAsync(obj.UserName);
        if (user != null)
        {
             await _userManager.AddToRoleAsync(user, obj.Role);
        }
    }

}