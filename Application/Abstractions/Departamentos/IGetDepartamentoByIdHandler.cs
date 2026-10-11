using Application.Commands.Departamentos;
using Application.Common;
using Application.DTOs;

namespace Application.Abstractions.Departamentos;

public interface IGetDepartamentoByIdHandler
{
    Task<Result<DepartamentoDTO?>> HandleAsync(GetDepartamentoByIdCommand command, CancellationToken ct = default);
}
