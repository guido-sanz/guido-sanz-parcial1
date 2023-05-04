namespace guido_sanz_parcial1.Models;

using System.ComponentModel.DataAnnotations;
public class Agency{

    public int Id { get; set; }

    [Display(Name="Nombre de agencia")]
    public string Name { get; set; }

    [Display(Name="Dirección")]
    public string Address { get; set; }

    [Display(Name="Contacto")]
    public string Phone { get; set; }
   
    public virtual List<Inventory>? Invertorys { get; set; }
}