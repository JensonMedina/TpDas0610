
namespace Domain.Abstractions;

public interface IUnitOfWork : IDisposable
{
    IEmpleadoRepository EmpleadoRepository { get; }
    IDepartamentoRepository DepartamentoRepository { get; }
    Task<int> SaveChangesAsync(CancellationToken ct);
}
