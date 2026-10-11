using Domain.Entities;

namespace Domain.Abstractions;

public interface ISueldoRepository
{
    Task AddAsync(Sueldo sueldo, CancellationToken ct = default);
    Task<List<Sueldo>> GetAllAsync(CancellationToken ct = default);
}
