namespace guido_sanz_parcial1.Models;
using System.ComponentModel.DataAnnotations;
public class Inventory{

    public int Id { get; set; }

    public int MotoId { get; set; }

    public int AgencyId { get; set; }
    [Range(0,1000)]
    [Display(Name="Cantidad")]
    public int Quantity { get; set; }

    public virtual Moto Moto { get; set; }

    public virtual Agency Agency { get; set; }    
    
}