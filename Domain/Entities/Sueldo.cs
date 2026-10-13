namespace Domain.Entities;

public class Sueldo
{
    public int Id { get; set; }
    public DateTime FechaCalculo { get; set; }
    public int EmpleadoId { get; set; }
    public Empleado Empleado { get; set; } = null!;
    public int HorasTrabajadas { get; set; }
    public double Adicional { get; set; } 
    public double MontoTotal { get; set; } 
}
