using guido_sanz_parcial1.Data;
using guido_sanz_parcial1.Models;
using guido_sanz_parcial1.ViewModels;

namespace guido_sanz_parcial1.Services;

public class AccesoryServiceImpl : IAccesoryService
{
    private readonly MotoContext _context;

    public AccesoryServiceImpl(MotoContext motoContext){
        _context = motoContext;
    }

    public void Delete(Accesory obj)
    {
        _context.Remove(obj);
        _context.SaveChangesAsync();
    }

    public AccesorySearchViewModel GetAll()
    {
        var query = GetQuery();
        AccesorySearchViewModel accesoryViewModel = new AccesorySearchViewModel();
        accesoryViewModel.Accesories = query.ToList();
        return accesoryViewModel;
    }

    public AccesorySearchViewModel GetAll(string nameFilter)
    {
        var query = GetQuery();
        query = query.Where(x => x.Name.ToLower().Contains(nameFilter.ToLower()) || x.SerialNumber.ToString().Contains(nameFilter));
        
        AccesorySearchViewModel accesoryViewModel = new AccesorySearchViewModel();
        accesoryViewModel.Accesories = query.ToList();
        return accesoryViewModel;
    }

    public Accesory? GetById(int id)
    {
        var accesory = _context.Accesory
                .FirstOrDefault(m => m.Id == id);
        return accesory;
    }

    public void Update(Accesory obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }

    private IQueryable<Accesory> GetQuery()
    {
        return from accesory in _context.Accesory select accesory;
    }
}