using Application.Abstractions;
using Application.Common;
using Application.Mappings;
using Domain.Abstractions;

namespace Application.Commands;

public sealed record CreateDepartamentoCommand(string Descripcion, double PrecioHora);

public sealed class CreateDepartamentoHandler(IUnitOfWork unitOfWork) : ICreateDepartamentoHandler
{
    public async Task<Result<int>> HandleAsync(CreateDepartamentoCommand command, CancellationToken ct = default)
    {
        var departamento = DepartamentoMapper.ToEntity(command);
        await unitOfWork.DepartamentoRepository.AddAsync(departamento, ct);
        int result = await unitOfWork.SaveChangesAsync(ct);
        return Result<int>.Success(result);
    }
}
