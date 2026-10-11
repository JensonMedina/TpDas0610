using Application.Commands.Empleados;
using Application.Common;
using Application.DTOs;

namespace Application.Abstractions.Empleados;

public interface ICreateEmpleadoHandler
{
    Task<Result<EmpleadoDTO>> HandleAsync(CreateEmpleadoCommand command, CancellationToken ct = default);
}
