using Application.Abstractions.Empleados;
using Application.Common;
using Application.DTOs;
using Application.Mappings;
using Domain.Abstractions;

namespace Application.Commands.Empleados;

public sealed record CreateEmpleadoCommand(string Nombre, string Apellido, int DepartamentoId, int Legajo, double SueldoBase, DateTime FechaIngreso);

public class CreateEmpleadoHandler(IUnitOfWork unitOfWork) : ICreateEmpleadoHandler
{
    public async Task<Result<EmpleadoDTO>> HandleAsync(CreateEmpleadoCommand command, CancellationToken ct = default)
    {
        if(command.FechaIngreso > DateTime.Now)
        {
            return Result<EmpleadoDTO>.Failure("La fecha de ingreso no puede ser superior a ahora.");
        }

        var existe = await unitOfWork.Empleados.ExistByLegajo(command.Legajo, ct);
        if (existe)
        {
            return Result<EmpleadoDTO>.Failure("Ya existe un empleado con el legajo indicado. Intente con un legajo distinto por favor.");
        }

        var departamento = await unitOfWork.Departamentos.GetByIdAsync(command.DepartamentoId, ct);
        if (departamento == null)
        {
            return Result<EmpleadoDTO>.Failure("El departamento especificado no existe.");
        }

        var empleado = EmpleadoMapper.ToEntity(command);

        empleado.Departamento = departamento;

        await unitOfWork.Empleados.AddAsync(empleado, ct);
        await unitOfWork.SaveChangesAsync(ct);

        return Result<EmpleadoDTO>.Success(EmpleadoMapper.ToDto(empleado));
    }
}
