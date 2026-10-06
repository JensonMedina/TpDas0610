using Domain.Entities;

namespace Domain.Abstractions;

public interface IEmpleadoRepository
{
    Task AddAsync(Empleado newEmpleado, CancellationToken ct = default);
    Task<List<Empleado>> GetAllAsync(CancellationToken ct = default);
    Task<Empleado?> GetByIdAsync(int id, CancellationToken ct = default);
}
