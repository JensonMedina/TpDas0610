using Application.Commands;
using Application.Common;

namespace Application.Abstractions;

public interface ICreateDepartamentoHandler
{
    Task<Result<int>> HandleAsync(CreateDepartamentoCommand command, CancellationToken ct = default);
}
