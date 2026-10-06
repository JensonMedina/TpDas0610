using Application.Abstractions;
using Application.Common;
using Application.Mappings;
using Domain.Abstractions;

namespace Application.Commands;

public sealed record CreateEmpleadoCommand(string Nombre, string Apellido, int DepartamentoId);

public class CreateEmpleadoHandler(IUnitOfWork unitOfWork) : ICreateEmpleadoHandler
{
    public async Task<Result<int>> HandleAsync(CreateEmpleadoCommand command, CancellationToken ct = default)
    {
        var empleado = EmpleadoMapper.ToEntity(command);
        await unitOfWork.EmpleadoRepository.AddAsync(empleado, ct);
        int result = await unitOfWork.SaveChangesAsync(ct);
        return Result<int>.Success(result);
    }
}
