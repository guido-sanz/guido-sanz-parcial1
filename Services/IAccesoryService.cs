using guido_sanz_parcial1.ViewModels;
using guido_sanz_parcial1.Models;
namespace guido_sanz_parcial1.Services;

public interface IAccesoryService
{
    AccesorySearchViewModel GetAll();
    void Update(Accesory obj);
    void Delete(Accesory obj);
    Accesory? GetById(int id);
    AccesorySearchViewModel GetAll(string nameFilter);
}