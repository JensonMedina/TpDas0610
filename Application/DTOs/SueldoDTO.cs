namespace Application.DTOs;

public sealed record SueldoDTO(int Id, EmpleadoDTO EmpleadoDTO, double SueldoBase, double Antiguedad, double Adicional, double Bruto, double Descuentos, double Neto);
