using guido_sanz_parcial1.Models;
using guido_sanz_parcial1.Data;
using guido_sanz_parcial1.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace guido_sanz_parcial1.Services;



public class MotoServiceImpl : IMotoService
{

    private readonly MotoContext _context;

    public MotoServiceImpl(MotoContext context){
        _context = context;
    }

    public void Delete(Moto obj)
    {
        _context.Remove(obj);
        _context.SaveChangesAsync();
    }

    public MotoViewModel GetAll()
    {
        var query = GetQuery();
        MotoViewModel motos = new MotoViewModel();
        motos.Motos = query.ToList();
        return motos;
    }

    public MotoViewModel GetAll(string nameFilter)
    {
        var query = GetQuery();
        query = query.Where(x => x.Brand.ToLower().Contains(nameFilter.ToLower()) || x.Model.ToLower().Contains(nameFilter.ToLower()));
        
        MotoViewModel motos = new MotoViewModel();
        motos.Motos = query.ToList();
        return motos;
    }

    public Moto? GetById(int id)
    {
        var moto = _context.Moto.Include(x => x.Accesories)
                .FirstOrDefault(m => m.Id == id);
        return moto;        
    }

    public void Update(MotoCreateViewModel model)
    {
        List<Accesory> accesories;
        var moto = model.Moto;
        if(model.SelectedAccesories != null && model.SelectedAccesories.Count() > 0){
            accesories = _context.Accesory.Where(a => model.SelectedAccesories.Contains(a.Id)).ToList();
            moto.Accesories = accesories;
        }       
        _context.Update(moto);
        _context.SaveChanges();
    }

    private IQueryable<Moto> GetQuery()
    {
        return from moto in _context.Moto select moto;
    }

    public bool ExistMotoWithBrandAndName(string brand, string model){
        bool exist = _context.Moto.Any(m => m.Model == model && m.Brand == brand);
        return exist;
    }


}