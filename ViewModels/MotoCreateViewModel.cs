using guido_sanz_parcial1.Models;

namespace guido_sanz_parcial1.ViewModels;

public class MotoCreateViewModel
{
    public Moto Moto {get; set;}

    public List<int>? SelectedAccesories {get; set;} = new List<int>();

    public List<Accesory>? Accesories {get; set;} 
}