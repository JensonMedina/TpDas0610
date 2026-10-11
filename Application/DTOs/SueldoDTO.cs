namespace Application.DTOs;

public sealed record SueldoDTO(int Id, DateTime FechaCalculo, EmpleadoDTO Empleado, int HorasTrabajadas, double MontoTotal);
