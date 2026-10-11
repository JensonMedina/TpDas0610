using Application.Abstractions.Departamentos;
using Application.Abstractions.Empleados;
using Application.Abstractions.Sueldos;
using Application.Commands.Departamentos;
using Application.Commands.Empleado;
using Application.Commands.Empleados;
using Application.Commands.Sueldo;
using Application.Commands.Sueldos;
using Application.Strategies;
using Domain.Abstractions;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Presentation;

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Information);


var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
var connectionString = $"Data Source={Path.Combine(baseDirectory, "Sueldo.db")}";
builder.Services.AddDbContext<MainContext>(options =>
{
    options.UseSqlite(connectionString);

    //Deshabilitar logs en consola
    options.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.CommandExecuted));
});

#region Repositories
builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
builder.Services.AddScoped<ISueldoRepository, SueldoRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
#endregion

#region EmpleadoCommands
builder.Services.AddScoped<ICreateEmpleadoHandler, CreateEmpleadoHandler>();
builder.Services.AddScoped<IGetAllEmpleadoHandler, GetAllEmpleadoHandler>();
builder.Services.AddScoped<IGetEmpleadoByIdHandler, GetEmpleadoByIdHandler>();
#endregion

#region DepartamentoCommands
builder.Services.AddScoped<ICreateDepartamentoHandler, CreateDepartamentoHandler>();
builder.Services.AddScoped<IGetAllDepartamentoHandler, GetAllDepartamentoHandler>();
builder.Services.AddScoped<IGetDepartamentoByIdHandler, GetDepartamentoByIdHandler>();
#endregion

#region Sueldo
builder.Services.AddScoped<ICalculateSueldoStrategy, StandarSueldoStrategy>();
builder.Services.AddScoped<ICreateSueldoHandler, CreateSueldoHandler>();
builder.Services.AddScoped<IGetSueldoHistoryHandler, GetSueldoHistoryHandler>();
#endregion

builder.Services.AddTransient<MenuPrincipal>();

using var host = builder.Build();

var menu = host.Services.GetRequiredService<MenuPrincipal>();
await menu.EjecutarAsync();