using guido_sanz_parcial1.Models;

namespace guido_sanz_parcial1.Services;

public interface IInventoryService
{
    List<Inventory> GetAll();
    List<Inventory> GetAll(string nameFiler);
    void Update(Inventory obj);
    void Delete(Inventory obj);
    Inventory? GetById(int id);
    Inventory? GetInventoryByAgencyIdAndMotoId(int agencyId, int motoId);

}