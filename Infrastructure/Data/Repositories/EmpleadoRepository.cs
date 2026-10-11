using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class EmpleadoRepository(MainContext context) : IEmpleadoRepository
{
    public async Task AddAsync(Empleado newEmpleado, CancellationToken ct = default)
    {
        await context.Empleados.AddAsync(newEmpleado, ct);
    }
    public async Task<List<Empleado>> GetAllAsync(CancellationToken ct = default)
    {
        return await context.Empleados.Include(e => e.Departamento).ToListAsync(ct);
    }
    public async Task<Empleado?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        return await context.Empleados.Include(e => e.Departamento).Where(e => e.Id == id).FirstOrDefaultAsync(ct);
    }
}
