using guido_sanz_parcial1.Models;
using guido_sanz_parcial1.ViewModels;

namespace guido_sanz_parcial1.Services;

public interface IMotoService
{
    MotoViewModel GetAll();
    void Update(MotoCreateViewModel obj);
    void Delete(Moto obj);
    Moto? GetById(int id);
    MotoViewModel GetAll(string nameFilter);
    bool ExistMotoWithBrandAndName(string brand, string model);
}