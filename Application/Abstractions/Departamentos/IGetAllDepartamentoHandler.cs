using Application.Commands.Departamentos;
using Application.Common;
using Application.DTOs;

namespace Application.Abstractions.Departamentos;

public interface IGetAllDepartamentoHandler
{
    Task<Result<List<DepartamentoDTO>>> HandleAsync(GetAllDepartamentoQuery query, CancellationToken ct = default);
}
