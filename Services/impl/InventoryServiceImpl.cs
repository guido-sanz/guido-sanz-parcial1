using guido_sanz_parcial1.Data;
using guido_sanz_parcial1.Models;

namespace guido_sanz_parcial1.Services;

public class InventoryServiceImpl : IInventoryService
{
    private readonly MotoContext _context;
    
    public InventoryServiceImpl(MotoContext context){
        _context = context;
    }

    public void Delete(Inventory obj)
    {
        _context.Inventory.Remove(obj);
    }

    public List<Inventory> GetAll()
    {
        List<Inventory> inventorys = new List<Inventory>();
        inventorys = _context.Inventory.ToList();
        return inventorys;
    }

    public List<Inventory> GetAll(string nameFiler)
    {
        throw new NotImplementedException();
    }

    public Inventory? GetById(int id)
    {
       return _context.Inventory.FirstOrDefault(m => m.Id == id);
    }

    public void Update(Inventory obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }
}