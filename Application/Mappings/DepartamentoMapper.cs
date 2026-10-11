using Application.Commands.Departamentos;
using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings;

public static class DepartamentoMapper
{
    public static Departamento ToEntity(CreateDepartamentoCommand command)
    {
        return new Departamento
        {
            Descripcion = command.Descripcion,
            PrecioHora = command.PrecioHora,
        };
    }
    public static DepartamentoDTO ToDto(Departamento departamento)
    {
        return new DepartamentoDTO(departamento.Id, departamento.Descripcion, departamento.PrecioHora);
    }
}
