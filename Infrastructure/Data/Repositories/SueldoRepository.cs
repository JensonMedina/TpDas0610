using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class SueldoRepository(MainContext context) : ISueldoRepository
{
    public async Task AddAsync(Sueldo sueldo, CancellationToken ct = default)
    {
        await context.Sueldos.AddAsync(sueldo, ct);
    }
    public async Task<List<Sueldo>> GetAllAsync(CancellationToken ct = default)
    {
        return await context.Sueldos.AsNoTracking().Include(s => s.Empleado).ThenInclude(e => e.Departamento).ToListAsync(ct);
    }
}
