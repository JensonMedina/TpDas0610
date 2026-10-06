namespace Domain.Entities;

public class Empleado
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public double Sueldo { get; set; } //Supongamos como regla de negocio el manejar valores de importes con double

    public int DepartamentoId { get; set; }
    public Departamento Departamento { get; set; } = null!;
}
