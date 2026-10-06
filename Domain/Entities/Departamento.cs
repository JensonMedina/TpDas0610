namespace Domain.Entities;

public class Departamento
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public double PrecioHora { get; set; } //Supongamos como regla de negocio el manejar valores de importes con double
}
