using Application.Commands.Empleados;
using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings;

public static class EmpleadoMapper
{
    public static Empleado ToEntity(CreateEmpleadoCommand command)
    {
        return new Empleado
        {
            Nombre = command.Nombre,
            Apellido = command.Apellido,
            DepartamentoId = command.DepartamentoId,
            Legajo = command.Legajo,
            SueldoBase = command.SueldoBase,
            FechaIngreso = command.FechaIngreso
        };
    }
    public static EmpleadoDTO ToDto(Empleado empleado)
    {
        var departamentoDto = DepartamentoMapper.ToDto(empleado.Departamento);
        return new EmpleadoDTO(empleado.Id, empleado.Nombre, empleado.Apellido, departamentoDto, empleado.Legajo, empleado.SueldoBase, empleado.FechaIngreso);
    }
}
