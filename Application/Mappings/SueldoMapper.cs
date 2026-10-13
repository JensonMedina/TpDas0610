using Application.Commands.Sueldos;
using Application.DTOs;
using Application.Strategies;
using Domain.Entities;

namespace Application.Mappings;

public static class SueldoMapper
{
    public static Sueldo ToEntity(CreateSueldoCommand command, StandarSueldo standarSueldo)
    {
        double bruto = standarSueldo.Bruto;
        double descuentos = bruto * 0.17;

        return new Sueldo
        {
            EmpleadoId = command.EmpleadoId,
            Bruto = bruto,
            Antiguedad = standarSueldo.Antiguedad,
            Adicional = standarSueldo.Adicional,
            Descuentos = descuentos,
            Neto = bruto - descuentos
        };
    }
    public static SueldoDTO ToDto(Sueldo sueldo)
    {
        var empleadoDto = EmpleadoMapper.ToDto(sueldo.Empleado);
        return new SueldoDTO(sueldo.Id, empleadoDto, empleadoDto.SueldoBase, sueldo.Antiguedad, sueldo.Adicional, sueldo.Bruto, sueldo.Descuentos, sueldo.Neto);
    }
}
