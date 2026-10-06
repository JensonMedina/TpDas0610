using Application.Commands;
using Application.Common;

namespace Application.Abstractions;

public interface ICreateEmpleadoHandler
{
    Task<Result<int>> HandleAsync(CreateEmpleadoCommand command, CancellationToken ct = default);
}
