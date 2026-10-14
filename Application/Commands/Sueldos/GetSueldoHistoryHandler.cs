using Application.Abstractions.Sueldos;
using Application.Common;
using Application.DTOs;
using Application.Mappings;
using Domain.Abstractions;

namespace Application.Commands.Sueldo;

public sealed record GetSueldoHistoryQuery(int DepartamentoId);//Aca se podrian agregar tantos campos como filtros se quieran aplicar a la busqueda, ejemplo empleado, departamento, fecha, min/max sueldo, etc.

//NO TERMINADO
public class GetSueldoHistoryHandler(IUnitOfWork unitOfWork) : IGetSueldoHistoryHandler
{
    public async Task<Result<List<SueldoDTO>>> HandleAsync(GetSueldoHistoryQuery query, CancellationToken ct = default)
    {
        var empleados = await unitOfWork.Empleados.GetAllByDepartamentoAsync(query.DepartamentoId, ct);

        var sueldos = await unitOfWork.Sueldos.GetAllAsync(ct);

        var result = sueldos.GroupBy(s => s.Empleado.Departamento);

        var sueldosResponse = sueldos.Select(s => SueldoMapper.ToDto(s)).ToList();
        return Result<List<SueldoDTO>>.Success(sueldosResponse);
    }
}
