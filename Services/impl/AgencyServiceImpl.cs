using guido_sanz_parcial1.Data;
using guido_sanz_parcial1.Models;
using guido_sanz_parcial1.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace guido_sanz_parcial1.Services;

public class AgencyServiceImpl : IAgencyService
{

    private readonly MotoContext _context;
    public AgencyServiceImpl(MotoContext motoContext){
        _context = motoContext;
    }
    public void Delete(Agency obj)
    {
        if(obj.Invertorys != null){
            _context.Inventory.RemoveRange(obj.Invertorys);
        }        
        _context.Agency.Remove(obj);
    }

    public Agency? GetAgencyWithInventoryById(int id)
    {
        var agency = _context.Agency.Include(x=> x.Invertorys).ThenInclude(i => i.Moto)
                .FirstOrDefault(m => m.Id == id);

        return agency;
    }

    public AgencyViewModel GetAll()
    {
        var query = GetQuery();
        AgencyViewModel agencys = new AgencyViewModel();
        agencys.Agencys = query.ToList();

        return agencys;
    }

    public AgencyViewModel GetAll(string nameFilter)
    {
        var query = GetQuery();
        query = query.Where(x => x.Name.ToLower().Contains(nameFilter.ToLower()) || x.Address.ToLower().Contains(nameFilter.ToLower()));

        AgencyViewModel agencys = new AgencyViewModel();
        agencys.Agencys = query.ToList();

        return agencys;
    }

    public Agency? GetById(int id)
    {
        var agency = _context.Agency.FirstOrDefault(m => m.Id == id);
        return agency;
    }

    public void Update(Moto obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }

    public void Update(Agency obj)
    {
        throw new NotImplementedException();
    }

    private IQueryable<Agency> GetQuery()
    {
        return from agency in _context.Agency select agency;
    }

}