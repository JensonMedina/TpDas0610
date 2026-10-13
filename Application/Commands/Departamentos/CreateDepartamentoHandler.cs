using Application.Abstractions.Departamentos;
using Application.Common;
using Application.DTOs;
using Application.Mappings;
using Domain.Abstractions;

namespace Application.Commands.Departamentos;

public sealed record CreateDepartamentoCommand(string Descripcion, double Adicional);

public sealed class CreateDepartamentoHandler(IUnitOfWork unitOfWork) : ICreateDepartamentoHandler
{
    public async Task<Result<DepartamentoDTO>> HandleAsync(CreateDepartamentoCommand command, CancellationToken ct = default)
    {
        if (command.Adicional<0 || command.Adicional>50)
        {
            return Result<DepartamentoDTO>.Failure("El valor adicional debe ser un numero entre 0 y 50.");
        }
        var departamento = DepartamentoMapper.ToEntity(command);
        await unitOfWork.Departamentos.AddAsync(departamento, ct);
        await unitOfWork.SaveChangesAsync(ct);
        return Result<DepartamentoDTO>.Success(DepartamentoMapper.ToDto(departamento));
    }
}
