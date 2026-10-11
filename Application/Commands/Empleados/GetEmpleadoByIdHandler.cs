using Application.Abstractions.Empleados;
using Application.Common;
using Application.DTOs;
using Application.Mappings;
using Domain.Abstractions;

namespace Application.Commands.Empleado;

public sealed record GetEmpleadoByIdCommand(int EmpleadoId);
public class GetEmpleadoByIdHandler(IUnitOfWork unitOfWork) : IGetEmpleadoByIdHandler
{
    public async Task<Result<EmpleadoDTO?>> HandleAsync(GetEmpleadoByIdCommand command, CancellationToken ct = default)
    {
        var empleado = await unitOfWork.Empleados.GetByIdAsync(command.EmpleadoId, ct);

        if (empleado == null)
            return Result<EmpleadoDTO?>.Failure("Empleado inexistente.");

        var empleadoResponse = EmpleadoMapper.ToDto(empleado);
        return Result<EmpleadoDTO?>.Success(empleadoResponse);
    }
}
