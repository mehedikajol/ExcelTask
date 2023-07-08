using ExcelTask.Application;
using ExcelTask.Application.IRepositories;
using ExcelTask.Application.IServices;
using ExcelTask.Infrastructure.Repositories;
using ExcelTask.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ExcelTask.Infrastructure;

public static class DependencyContainer
{
    public static void AddInfrastructureDependencies(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IDiseaseRepository, DiseaseRepository>();
        services.AddScoped<IAllergiesRepository, AllergiesRepository>();
        services.AddScoped<INCDRepository, NCDRepository>();

        services.AddScoped<IPatientService, PatientService>();
        services.AddScoped<IDiseaseService, DiseaseService>();
        services.AddScoped<IAllergiesService, AllergiesService>();
        services.AddScoped<INCDService, NCDService>();
    }
}
