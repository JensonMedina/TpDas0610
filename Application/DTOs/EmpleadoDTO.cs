namespace Application.DTOs;

public sealed record EmpleadoDTO(int Id, string Nombre, string Apellido, DepartamentoDTO Departamento, int Legajo, double SueldoBase, DateTime FechaIngreso);
