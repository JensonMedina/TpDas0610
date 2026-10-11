namespace Domain.Entities;

public class Sueldo
{
    public int Id { get; set; }
    public DateTime FechaCalculo { get; set; }
    public int EmpleadoId { get; set; }
    public Empleado Empleado { get; set; } = null!;
    public int HorasTrabajadas { get; set; }
    public double PrecioHora { get; set; } //Sirve como snapshot
    public double MontoTotal { get; set; } //Sirve para no estar calculandolo cada vez que se quiera obtener
}
