namespace guido_sanz_parcial1.Services;
using Microsoft.AspNetCore.Identity;
using guido_sanz_parcial1.ViewModels;

public interface IUsersService
{
    List<IdentityUser> GetAll();
    void Update(UserEditViewModel obj);
    void Delete(UserEditViewModel obj);
    Task<UserEditViewModel?> GetById(string id);
    UserEditViewModel GetAll(string nameFilter);
}