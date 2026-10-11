using Domain.Entities;

namespace Application.Abstractions.Sueldos;

public interface ICalculateSueldoStrategy
{
    double Calculate(Departamento departamento, double horasTrabajadas);
}
