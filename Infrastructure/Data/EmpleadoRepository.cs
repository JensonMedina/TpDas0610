using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class EmpleadoRepository(MainContext context) : IEmpleadoRepository
{
    public async Task AddAsync(Empleado newEmpleado, CancellationToken ct = default)
    {
        await context.Empleados.AddAsync(newEmpleado, ct);
    }
    public async Task<List<Empleado>> GetAllAsync(CancellationToken ct = default)
    {
        return await context.Empleados.ToListAsync(ct);
    }
    public async Task<Empleado?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        return await context.Empleados.Where(e => e.Id == id).FirstOrDefaultAsync(ct);
    }
}
