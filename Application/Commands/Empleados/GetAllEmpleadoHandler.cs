using Application.Abstractions.Empleados;
using Application.Common;
using Application.DTOs;
using Application.Mappings;
using Domain.Abstractions;

namespace Application.Commands.Empleado;

public sealed record GetAllEmpleadoQuery();
public class GetAllEmpleadoHandler(IUnitOfWork unitOfWork) : IGetAllEmpleadoHandler
{
    public async Task<Result<List<EmpleadoDTO>>> HandleAsync(GetAllEmpleadoQuery query, CancellationToken ct = default)
    {
        var empleados = await unitOfWork.Empleados.GetAllAsync(ct);
        var empleadosResponse = empleados.Select(e => EmpleadoMapper.ToDto(e)).ToList();
        return Result<List<EmpleadoDTO>>.Success(empleadosResponse);
    }
}
