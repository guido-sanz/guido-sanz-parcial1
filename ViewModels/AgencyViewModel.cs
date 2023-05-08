using guido_sanz_parcial1.Models;

namespace guido_sanz_parcial1.ViewModels;

public class AgencyViewModel{

    public List<Agency> Agencys { get; set;}

    public string? NameFilter { get; set; }

    public Agency Agency { get; set;} = new();

}