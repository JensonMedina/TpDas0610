using Application.Commands.Departamentos;
using Application.Common;
using Application.DTOs;

namespace Application.Abstractions.Departamentos;

public interface ICreateDepartamentoHandler
{
    Task<Result<DepartamentoDTO>> HandleAsync(CreateDepartamentoCommand command, CancellationToken ct = default);
}
