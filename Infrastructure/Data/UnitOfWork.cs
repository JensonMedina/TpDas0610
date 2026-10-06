using Domain.Abstractions;

namespace Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly MainContext _context;
    public IDepartamentoRepository DepartamentoRepository { get; private set; }
    public IEmpleadoRepository EmpleadoRepository { get; private set; }

    public UnitOfWork(MainContext context)
    {
        _context = context;
        this.DepartamentoRepository = new DepartamentoRepository(_context);
        this.EmpleadoRepository = new EmpleadoRepository(_context);
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
