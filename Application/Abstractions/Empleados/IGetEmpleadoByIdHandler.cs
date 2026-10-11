using Application.Commands.Empleado;
using Application.Common;
using Application.DTOs;

namespace Application.Abstractions.Empleados;

public interface IGetEmpleadoByIdHandler
{
    Task<Result<EmpleadoDTO?>> HandleAsync(GetEmpleadoByIdCommand command, CancellationToken ct = default);
}
