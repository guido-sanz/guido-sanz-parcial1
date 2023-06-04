using System.ComponentModel.DataAnnotations;

namespace guido_sanz_parcial1.ViewModels;

public class RoleCreateViewModel
{
    
    [Display(Name="Nombre del rol")]
    public string RoleName { get; set; }
}