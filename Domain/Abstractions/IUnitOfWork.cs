
namespace Domain.Abstractions;

public interface IUnitOfWork : IDisposable
{
    IEmpleadoRepository Empleados { get; }
    IDepartamentoRepository Departamentos { get; }
    ISueldoRepository Sueldos { get; }

    Task<int> SaveChangesAsync(CancellationToken ct);
}
