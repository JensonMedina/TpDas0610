using Application.Commands;
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
            DepartamentoId = command.DepartamentoId
        };
    }
    public static EmpleadoDTO ToDto(Empleado empleado)
    {
        return new EmpleadoDTO(empleado.Id, empleado.Nombre, empleado.Apellido, empleado.Sueldo);
    }
}
