using Application.Abstractions.Sueldos;
using Domain.Entities;

namespace Application.Strategies;

public sealed record StandarSueldo(int Antiguedad, double Adicional, double Bruto); 

public sealed class StandarSueldoStrategy : ICalculateSueldoStrategy
{
    public StandarSueldo Calculate(Empleado empleado)
    {
        ArgumentNullException.ThrowIfNull(empleado);

        double sueldoBase = empleado.SueldoBase;

        int antiguedad = CalcularAntiguedad(empleado.FechaIngreso);

        double adicional = sueldoBase * empleado.Departamento.Adicional;

        double sueldoBruto = sueldoBase + antiguedad * 0.01 + adicional; 

        return new StandarSueldo(antiguedad, adicional, sueldoBruto);
    }

    private static int CalcularAntiguedad(DateTime fechaIngreso)
    {
        DateTime fechaActual = DateTime.Today;

        // 1. Resta inicial de los años
        int anios = fechaActual.Year - fechaIngreso.Year;

        // 2. Ajuste condicional: Si no ha llegado al mes/día de ingreso, restamos 1 año
        if (fechaActual < fechaIngreso.AddYears(anios))
        {
            anios--;
        }
        return anios;
    }

}
