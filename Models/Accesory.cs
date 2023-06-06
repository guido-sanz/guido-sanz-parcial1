using System.ComponentModel.DataAnnotations;

namespace guido_sanz_parcial1.Models;

public class Accesory
{
    public int Id { get; set; }
    [Display(Name="Nombre del producto")]
    public string Name { get; set; }

    [Display(Name="Número de serie")]
    public int SerialNumber{get; set;}

    public virtual List<Moto>? Motos {get; set;} 

}