using Application.Abstractions.Empleados;
using Application.Common;
using Application.DTOs;
using Application.Mappings;
using Domain.Abstractions;

namespace Application.Commands.Empleados;

public sealed record CreateEmpleadoCommand(string Nombre, string Apellido, int DepartamentoId);

public class CreateEmpleadoHandler(IUnitOfWork unitOfWork) : ICreateEmpleadoHandler
{
    public async Task<Result<EmpleadoDTO>> HandleAsync(CreateEmpleadoCommand command, CancellationToken ct = default)
    {
        // 1. Validar y obtener el departamento previamente
        var departamento = await unitOfWork.Departamentos.GetByIdAsync(command.DepartamentoId, ct);
        if (departamento == null)
        {
            return Result<EmpleadoDTO>.Failure("El departamento especificado no existe.");
        }

        // 2. Crear la entidad empleado
        var empleado = EmpleadoMapper.ToEntity(command);

        // 3. Asignar explícitamente la navegación en memoria
        empleado.Departamento = departamento;

        // 4. Persistir
        await unitOfWork.Empleados.AddAsync(empleado, ct);
        await unitOfWork.SaveChangesAsync(ct);

        return Result<EmpleadoDTO>.Success(EmpleadoMapper.ToDto(empleado));
    }
}
