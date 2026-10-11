using Domain.Abstractions;
using Infrastructure.Data.Repositories;

namespace Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly MainContext _context;
    public IDepartamentoRepository Departamentos { get; private set; }
    public IEmpleadoRepository Empleados { get; private set; }
    public ISueldoRepository Sueldos { get; private set; }

    public UnitOfWork(MainContext context)
    {
        _context = context;
        this.Departamentos = new DepartamentoRepository(_context);
        this.Empleados = new EmpleadoRepository(_context);
        this.Sueldos = new SueldoRepository(_context);
    }
    public async Task<int> SaveChangesAsync(CancellationToken ct)
    {
        return await _context.SaveChangesAsync(ct);
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}
