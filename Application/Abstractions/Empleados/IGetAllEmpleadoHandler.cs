using Application.Commands.Empleado;
using Application.Common;
using Application.DTOs;

namespace Application.Abstractions.Empleados;

public interface IGetAllEmpleadoHandler
{
    Task<Result<List<EmpleadoDTO>>> HandleAsync(GetAllEmpleadoQuery query, CancellationToken ct = default);
}
