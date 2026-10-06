using Domain.Entities;

namespace Domain.Abstractions;

public interface IDepartamentoRepository
{
    Task AddAsync(Departamento newDepartamento, CancellationToken ct = default);
    Task<List<Departamento>> GetAllAsync(CancellationToken ct = default);
    Task<Departamento?> GetByIdAsync(int id, CancellationToken ct = default);
}
