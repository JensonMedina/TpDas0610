using Application.Abstractions.Sueldos;
using Application.Common;
using Application.DTOs;
using Application.Mappings;
using Domain.Abstractions;

namespace Application.Commands.Sueldos;

public sealed record CreateSueldoCommand(int EmpleadoId, int HorasTrabajadas);
public class CreateSueldoHandler(IUnitOfWork unitOfWork, ICalculateSueldoStrategy sueldoStrategy) : ICreateSueldoHandler
{
    public async Task<Result<SueldoDTO>> HandleAsync(CreateSueldoCommand command, CancellationToken ct = default)
    {
        var empleado = await unitOfWork.Empleados.GetByIdAsync(command.EmpleadoId, ct);

        if (empleado == null)
            return Result<SueldoDTO>.Failure("Empleado inexistente.");

        var departamento = await unitOfWork.Departamentos.GetByIdAsync(empleado.DepartamentoId, ct);

        if (departamento == null)
            return Result<SueldoDTO>.Failure("Departamento inexistente.");

        var montoSueldo = sueldoStrategy.Calculate(departamento, command.HorasTrabajadas);

        var sueldo = SueldoMapper.ToEntity(command, departamento.PrecioHora, montoSueldo);

        await unitOfWork.Sueldos.AddAsync(sueldo, ct);
        await unitOfWork.SaveChangesAsync(ct);

        var entityDto = SueldoMapper.ToDto(sueldo);

        return Result<SueldoDTO>.Success(entityDto);
    }
}
