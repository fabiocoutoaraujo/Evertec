using FCA.Application.Interfaces;
using FCA.Application.Mappings;
using FCA.Application.Services;
using FCA.Domain.Interfaces;
using FCA.Infrastructure.Context;
using FCA.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FCA.CrossCutting.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                                                            IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IProprietarioRepository, ProprietarioRepository>();
        services.AddScoped<IVeiculoRepository, VeiculoRepository>();
        services.AddScoped<IProprietarioService, ProprietarioService>();
        services.AddScoped<IVeiculoService, VeiculoService>();

        services.AddAutoMapper(options => options.AddProfile(typeof(DomainToDTOMappingProfile)));

        return services;
    }
}
