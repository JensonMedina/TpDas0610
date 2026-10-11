using Application.Abstractions.Departamentos;
using Application.Common;
using Application.DTOs;
using Application.Mappings;
using Domain.Abstractions;

namespace Application.Commands.Departamentos;

public sealed record GetDepartamentoByIdCommand(int DepartamentoId);

public class GetDepartamentoByIdHandler(IUnitOfWork unitOfWork) : IGetDepartamentoByIdHandler
{
    public async Task<Result<DepartamentoDTO?>> HandleAsync(GetDepartamentoByIdCommand command, CancellationToken ct = default)
    {
        var departamento = await unitOfWork.Departamentos.GetByIdAsync(command.DepartamentoId, ct);

        if (departamento == null)
            return Result<DepartamentoDTO?>.Failure("Departamento inexistente.");

        var departamentoResponse = DepartamentoMapper.ToDto(departamento);
        return Result<DepartamentoDTO?>.Success(departamentoResponse);
    }
}
