using guido_sanz_parcial1.Models;

namespace guido_sanz_parcial1.ViewModels;

public class InventoryCreate{

    public int AgencyId { get; set;}

    public List<Moto> Motos { get; set;}

    public Inventory Inventory  { get; set;}  
}