using Application.Strategies;
using Domain.Entities;

namespace Application.Abstractions.Sueldos;

public interface ICalculateSueldoStrategy
{
    StandarSueldo Calculate(Empleado empleado);
}
