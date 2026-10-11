using Application.Commands.Sueldos;
using Application.Common;
using Application.DTOs;

namespace Application.Abstractions.Sueldos;

public interface ICreateSueldoHandler
{
    Task<Result<SueldoDTO>> HandleAsync(CreateSueldoCommand command, CancellationToken ct = default);
}
