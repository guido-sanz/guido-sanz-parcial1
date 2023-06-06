namespace guido_sanz_parcial1.Models;

public class Accesory
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int SerialNumber{get; set;}

    public virtual List<Moto>? Motos {get; set;} 

}