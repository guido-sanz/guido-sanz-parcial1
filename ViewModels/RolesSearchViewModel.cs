using Microsoft.AspNetCore.Identity;

namespace guido_sanz_parcial1.ViewModels;

public class RolesSearchViewModel{

    public List<IdentityRole>? Roles { get; set;} = new List<IdentityRole>();

    public string? nameFilter { get; set; }

}