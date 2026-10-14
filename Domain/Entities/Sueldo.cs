namespace Domain.Entities;

//básico, antigüedad, adicional, bruto, descuentos, neto
public class Sueldo
{
    public int Id { get; set; }
    public int EmpleadoId { get; set; }
    public Empleado Empleado { get; set; } = null!;
    public double Antiguedad { get; set; }
    public double Adicional { get; set; } //Snapshot
    public double Bruto { get; set; } 
    public double Descuentos { get; set; }
    public double Neto { get; set; }
}
