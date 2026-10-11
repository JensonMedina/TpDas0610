using System.Globalization;
using Application.Abstractions.Departamentos;
using Application.Abstractions.Empleados;
using Application.Abstractions.Sueldos;
using Application.Commands.Departamentos;
using Application.Commands.Empleado;
using Application.Commands.Empleados;
using Application.Commands.Sueldo;
using Application.Commands.Sueldos;
using Application.Common;
using Application.DTOs;
using Microsoft.Extensions.Logging;

namespace Presentation
{
    public class MenuPrincipal(ILogger<MenuPrincipal> logger,
        ICreateDepartamentoHandler createDepartamentoHandler,
        IGetAllDepartamentoHandler getAllDepartamentoHandler,
        ICreateEmpleadoHandler createEmpleadoHandler,
        IGetAllEmpleadoHandler getAllEmpleadoHandler,
        ICreateSueldoHandler createSueldoHandler,
        IGetSueldoHistoryHandler getSueldoHistoryHandler)
    {
        private CultureInfo culturaArgentina = new CultureInfo("es-AR");
        public async Task EjecutarAsync()
        {
            var salir = false;

            while (!salir)
            {
                MostrarMenu();
                var opcion = System.Console.ReadLine();
                try
                {
                    switch (opcion)
                    {
                        case "1":
                            await CreateDepartamentoAsync();
                            break;
                        case "2":
                            await ListarDepartamentosAsync();
                            break;
                        case "3":
                            await CreateEmpleadoAsync();
                            break;
                        case "4":
                            await ListarEmpleadosAsync();
                            break;
                        case "5":
                            await CalcularSueldoAsync();
                            break;
                        case "6":
                            await ListarSueldosAsync();
                            break;
                        case "7":
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("Opcion invalida. Presione una tecla para continuar...");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Error ejecutando la opción {Opcion}", opcion);
                    System.Console.WriteLine($"Ocurrió un error: {ex.Message}\n");
                }
            }
        }

        private static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("=== SISTEMA DE GESTION DE SUELDOS ===");
            Console.WriteLine("1. Crear Departamento");
            Console.WriteLine("2. Listar Departamentos");
            Console.WriteLine("3. Crear Empleado");
            Console.WriteLine("4. Listar Empleados");
            Console.WriteLine("5. Calcular Sueldo");
            Console.WriteLine("6. Ver Sueldos Registrados");
            Console.WriteLine("7. Salir");
            Console.Write("\nSeleccione una opcion: ");
        }
        private async Task CreateDepartamentoAsync()
        {
            var descripcion = LeerTexto("Descripcion: ");
            var precioHora = LeerDouble("Valor hora: ");

            Result<DepartamentoDTO> resultado = await createDepartamentoHandler.HandleAsync(new CreateDepartamentoCommand(descripcion, precioHora));

            if (resultado.IsSuccess)
            {
                Console.WriteLine("\n¡Operación exitosa!");
                Console.WriteLine($"ID Creado: {resultado.Value.Id}");
                Console.WriteLine($"Descripción: {resultado.Value.Descripcion}");
            }
            else
            {
                Console.WriteLine("\nError al procesar la operación:");
                Console.WriteLine($"[Error]: {resultado.Error}");
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
        private async Task ListarDepartamentosAsync()
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE DEPARTAMENTOS ===");

            var resultado = await getAllDepartamentoHandler.HandleAsync(new GetAllDepartamentoQuery());

            if (resultado.IsSuccess)
            {
                if (resultado.Value.Count > 0)
                {
                    foreach (var dept in resultado.Value)
                    {
                        Console.WriteLine($"ID: {dept.Id} | Descripcion: {dept.Descripcion} | Precio Hora: ${dept.PrecioHora}");
                    }
                }
                else
                {
                    Console.WriteLine("Aún no hay departamentos registrados.");
                }
            }
            else
            {
                Console.WriteLine("\nError al procesar la operación:");
                Console.WriteLine($"[Error]: {resultado.Error}");
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
        private async Task CreateEmpleadoAsync()
        {
            Console.Clear();
            Console.WriteLine("=== NUEVO EMPLEADO ===");
            var nombre = LeerTexto("Nombre del empleado: ");
            var apellido = LeerTexto("Apellido del empleado: ");
            var departamentoId = LeerInt("ID del Departamento al que pertenece: ");

            var resultado = await createEmpleadoHandler.HandleAsync(new CreateEmpleadoCommand(nombre, apellido, departamentoId));

            if (resultado.IsSuccess)
            {
                Console.WriteLine("\n¡Empleado creado con éxito!");
                Console.WriteLine($"ID: {resultado.Value.Id} | Nombre: {resultado.Value.Nombre} {resultado.Value.Apellido} | Depto: {resultado.Value.Departamento.Descripcion}");
            }
            else
            {
                Console.WriteLine("\nError al crear el empleado:");
                Console.WriteLine($"[Error]: {resultado.Error}");
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
        private async Task ListarEmpleadosAsync()
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE EMPLEADOS ===");

            var resultado = await getAllEmpleadoHandler.HandleAsync(new GetAllEmpleadoQuery());

            if (resultado.IsSuccess)
            {
                if (resultado.Value.Count > 0)
                {
                    foreach (var emp in resultado.Value)
                    {
                        Console.WriteLine($"ID: {emp.Id} | Nombre: {emp.Nombre} {emp.Apellido} | Depto ID: {emp.Departamento.Id}");
                    }
                }
                else
                {
                    Console.WriteLine("Aún no hay empleados registrados.");
                }
            }
            else
            {
                Console.WriteLine("\nError al procesar la operación:");
                Console.WriteLine($"[Error]: {resultado.Error}");
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
        private async Task CalcularSueldoAsync()
        {
            Console.Clear();
            Console.WriteLine("=== CALCULAR SUELDO ===");

            var empleadoId = LeerInt("Ingrese el ID del Empleado: ");
            var horasTrabajadas = LeerInt("Ingrese las horas trabajadas: ");

            var resultado = await createSueldoHandler.HandleAsync(new CreateSueldoCommand(empleadoId, horasTrabajadas));

            if (resultado.IsSuccess)
            {
                Console.WriteLine("\n¡Sueldo calculado y registrado con éxito!");
                Console.WriteLine($"ID Liquidación: {resultado.Value.Id}");
                Console.WriteLine($"Empleado ID: {resultado.Value.Empleado.Id}");
                Console.WriteLine($"Horas Trabajadas: {resultado.Value.HorasTrabajadas}");
                Console.WriteLine($"Monto Total Calculado: {resultado.Value.MontoTotal.ToString("C", culturaArgentina)}");
                Console.WriteLine($"Fecha: {resultado.Value.FechaCalculo}");
            }
            else
            {
                Console.WriteLine("\nNo se pudo calcular el sueldo:");
                Console.WriteLine($"[Error]: {resultado.Error}");
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
        private async Task ListarSueldosAsync()
        {
            Console.Clear();
            Console.WriteLine("=== HISTORIAL DE SUELDOS REGISTRADOS ===");

            var resultado = await getSueldoHistoryHandler.HandleAsync(new GetSueldoHistoryQuery());

            if (resultado.IsSuccess)
            {
                if (resultado.Value.Count > 0)
                {
                    foreach (var s in resultado.Value)
                    {
                        Console.WriteLine($"ID: {s.Id} | Empleado ID: {s.Empleado.Id} | Horas: {s.HorasTrabajadas} | Total: {s.MontoTotal.ToString("C", culturaArgentina)} | Fecha: {s.FechaCalculo}");
                    }
                }
                else
                {
                    Console.WriteLine("Aún no hay sueldos registrados.");
                }
            }
            else
            {
                Console.WriteLine("\nError al procesar la operación:");
                Console.WriteLine($"[Error]: {resultado.Error}");
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
        private static string LeerTexto(string etiqueta)
        {
            string? valor;
            do
            {
                System.Console.Write(etiqueta);
                valor = System.Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(valor));

            return valor.Trim();
        }
        private static double LeerDouble(string etiqueta)
        {
            while (true)
            {
                System.Console.Write(etiqueta);
                if (double.TryParse(System.Console.ReadLine(), out double valor))
                {
                    return valor;
                }
                System.Console.WriteLine("Ingrese un número válido.");
            }
        }
        private static int LeerInt(string etiqueta)
        {
            while (true)
            {
                System.Console.Write(etiqueta);
                if (int.TryParse(System.Console.ReadLine(), out int valor))
                {
                    return valor;
                }
                System.Console.WriteLine("Ingrese un número entero válido.");
            }
        }
    }
}
