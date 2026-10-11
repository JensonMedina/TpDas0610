using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class DepartamentoRepository(MainContext context) : IDepartamentoRepository
{
    public async Task AddAsync(Departamento newDepartamento, CancellationToken ct = default)
    {
        await context.Departamentos.AddAsync(newDepartamento, ct);
    }
    public async Task<List<Departamento>> GetAllAsync(CancellationToken ct = default)
    {
        return await context.Departamentos.ToListAsync(ct);
    }
    public async Task<Departamento?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        return await context.Departamentos.Where(e => e.Id == id).FirstOrDefaultAsync(ct);
    }
}
