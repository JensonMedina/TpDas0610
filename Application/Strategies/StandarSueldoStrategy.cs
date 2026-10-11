using Application.Abstractions.Sueldos;
using Domain.Entities;

namespace Application.Strategies;

public class StandarSueldoStrategy : ICalculateSueldoStrategy
{
    public double Calculate(Departamento departamento, double horasTrabajadas)
    {
        ArgumentNullException.ThrowIfNull(departamento);

        return horasTrabajadas * departamento.PrecioHora;
    }
}
