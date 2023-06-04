using Microsoft.AspNetCore.Identity;

namespace guido_sanz_parcial1.ViewModels;

public class UserSearchViewModel{

    public List<IdentityUser>? Users { get; set;}

    public string? UsernameFilter { get; set; }

}