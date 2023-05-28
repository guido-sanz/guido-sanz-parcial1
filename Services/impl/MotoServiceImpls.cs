using guido_sanz_parcial1.Models;
using guido_sanz_parcial1.Data;
using guido_sanz_parcial1.ViewModels;

namespace guido_sanz_parcial1.Services;



public class MotoServiceImpl : IMotoService
{

    private readonly MotoContext _context;

    public MotoServiceImpl(MotoContext context){
        _context = context;
    }

    public void Delete(Moto obj)
    {
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
        query = query.Where(x => x.Brand.ToLower().Contains(nameFilter.ToLower()));
        
        MotoViewModel motos = new MotoViewModel();
        motos.Motos = query.ToList();
        return motos;
    }

    public Moto? GetById(int id)
    {
        var moto = _context.Moto
                .FirstOrDefault(m => m.Id == id);
        return moto;        
    }

    public void Update(Moto obj)
    {
        _context.Update(obj);
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