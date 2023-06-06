using guido_sanz_parcial1.Models;

namespace guido_sanz_parcial1.ViewModels;

public class AccesorySearchViewModel
{
    public List<Accesory> Accesories {get; set;} = new List<Accesory>();

    public string? NameFilter { get; set; }
}