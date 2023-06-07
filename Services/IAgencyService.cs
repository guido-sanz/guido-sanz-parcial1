using guido_sanz_parcial1.Models;
using guido_sanz_parcial1.ViewModels;

namespace guido_sanz_parcial1.Services;

public interface IAgencyService
{
    AgencyViewModel GetAll();
    AgencyViewModel GetAll(string nameFilter);
    void Update(Agency obj);
    void Delete(Agency obj);
    Agency? GetById(int id);
    AgencyViewModel? GetAgencyWithInventoryById(int id);


}