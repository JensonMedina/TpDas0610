using Application.Commands.Sueldos;
using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings;

public static class SueldoMapper
{
    public static Sueldo ToEntity(CreateSueldoCommand command, double precioHora, double montoTotal)
    {
        return new Sueldo
        {
            FechaCalculo = DateTime.Now,
            EmpleadoId = command.EmpleadoId,
            HorasTrabajadas = command.HorasTrabajadas,
            PrecioHora = precioHora,
            MontoTotal = montoTotal
        };
    }
    public static SueldoDTO ToDto(Sueldo sueldo)
    {
        var empleadoDto = EmpleadoMapper.ToDto(sueldo.Empleado);
        return new SueldoDTO(sueldo.Id, sueldo.FechaCalculo, empleadoDto, sueldo.HorasTrabajadas, sueldo.MontoTotal);
    }
}
