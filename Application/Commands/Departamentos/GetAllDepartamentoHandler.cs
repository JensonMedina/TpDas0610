using Application.Abstractions.Departamentos;
using Application.Common;
using Application.DTOs;
using Application.Mappings;
using Domain.Abstractions;

namespace Application.Commands.Departamentos;

public sealed record GetAllDepartamentoQuery();
public class GetAllDepartamentoHandler(IUnitOfWork unitOfWork) : IGetAllDepartamentoHandler
{
    public async Task<Result<List<DepartamentoDTO>>> HandleAsync(GetAllDepartamentoQuery query, CancellationToken ct = default)
    {
        var departamentos = await unitOfWork.Departamentos.GetAllAsync(ct);

        var departamentosResponse = departamentos.Select(d => DepartamentoMapper.ToDto(d)).ToList();
        return Result<List<DepartamentoDTO>>.Success(departamentosResponse);
    }
}
