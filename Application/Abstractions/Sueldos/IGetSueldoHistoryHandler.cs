using Application.Commands.Sueldo;
using Application.Common;
using Application.DTOs;

namespace Application.Abstractions.Sueldos;

public interface IGetSueldoHistoryHandler
{
    Task<Result<List<SueldoDTO>>> HandleAsync(GetSueldoHistoryQuery query, CancellationToken ct = default);
}
