using guido_sanz_parcial1.Models;

namespace guido_sanz_parcial1.ViewModels;

public class MotoViewModel{

    public List<Moto> Motos { get; set;}

    public string? NameFilter { get; set; }

    public Moto Moto { get; set;} = new();

}