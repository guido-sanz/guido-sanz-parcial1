using guido_sanz_parcial1.Models;

namespace guido_sanz_parcial1.ViewModels;

public class AccesorySearchViewModel
{
    List<Accesory> accesories {get; set;} = new List<Accesory>();

    public string? nameFilter { get; set; }
}