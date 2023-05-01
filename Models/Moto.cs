using guido_sanz_parcial1.Utils;

namespace guido_sanz_parcial1.Models;

public class Moto{

    public int Id { get; set; }

    public String Brand { get; set; }

    public String Model { get; set; }

    public int CubicCentimeters { get; set; }

    public MotoType Type { get; set; }

    public double Price { get; set; }

}