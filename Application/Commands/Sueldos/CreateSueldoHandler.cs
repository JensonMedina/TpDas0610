using Application.Abstractions.Sueldos;
using Application.Common;
using Application.DTOs;
using Application.Mappings;
using Application.Strategies;
using Domain.Abstractions;

namespace Application.Commands.Sueldos;

public sealed record CreateSueldoCommand(int EmpleadoId);
public class CreateSueldoHandler(IUnitOfWork unitOfWork, ICalculateSueldoStrategy sueldoStrategy) : ICreateSueldoHandler
{
    public async Task<Result<SueldoDTO>> HandleAsync(CreateSueldoCommand command, CancellationToken ct = default)
    {
        var empleado = await unitOfWork.Empleados.GetByIdAsync(command.EmpleadoId, ct);

        if (empleado == null)
            return Result<SueldoDTO>.Failure("Empleado inexistente.");

        StandarSueldo standarSueldo = sueldoStrategy.Calculate(empleado);
        var sueldo = SueldoMapper.ToEntity(command, standarSueldo);

        await unitOfWork.Sueldos.AddAsync(sueldo, ct);
        await unitOfWork.SaveChangesAsync(ct);

        var entityDto = SueldoMapper.ToDto(sueldo);

        return Result<SueldoDTO>.Success(entityDto);
    }
}
