using Application.Abstractions.Sueldos;
using Domain.Entities;

namespace Application.Strategies;

public sealed record StandarSueldo(double Antiguedad, double Adicional, double Bruto); 

public sealed class StandarSueldoStrategy : ICalculateSueldoStrategy
{
    public StandarSueldo Calculate(Empleado empleado)
    {
        ArgumentNullException.ThrowIfNull(empleado);

        double sueldoBase = empleado.SueldoBase;

        int aniosAntiguedad = CalcularAntiguedad(empleado.FechaIngreso);
        double antiguedad = (aniosAntiguedad * 0.01 * sueldoBase);

        double adicional = sueldoBase * empleado.Departamento.Adicional / 100;

        double sueldoBruto = sueldoBase + antiguedad + adicional; 

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
