namespace guido_sanz_parcial1.Models;
using System.ComponentModel.DataAnnotations;
public class Inventory{

    public int Id { get; set; }

    public int IdMoto { get; set; }

    public int IdAgency { get; set; }
    [Range(1,1000)]
    public int Quantity { get; set; }

    public virtual Moto? Moto { get; set; }

    public virtual Agency? Agency { get; set; }    
    
}