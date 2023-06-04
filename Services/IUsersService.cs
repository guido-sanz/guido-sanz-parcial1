namespace guido_sanz_parcial1.Services;
using Microsoft.AspNetCore.Identity;
using guido_sanz_parcial1.ViewModels;

public interface IUsersService
{
    List<IdentityUser> GetAll();

    List<IdentityUser> GetAll(string usernameFilter);
    void Update(UserEditViewModel obj);
    void Delete(UserEditViewModel obj);
    Task<UserEditViewModel?> GetById(string id);
}