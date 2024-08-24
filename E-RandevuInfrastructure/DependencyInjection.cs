using E_RandevuApplication.Services;
using E_RandevuDomain.Entities;
using E_RandevuDomain.Repositories;
using E_RandevuInfrastructure.Context;
using E_RandevuInfrastructure.Repositories;
using E_RandevuInfrastructure.Services;
using GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace E_RandevuInfrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
    {
       
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("PostgreSql"));
        });
        services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 1;

            })
            .AddEntityFrameworkStores<ApplicationDbContext>();
        services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<ApplicationDbContext>());

        services.Scan(action =>
        {
            action.FromAssemblies(typeof(DependencyInjection).Assembly)
                .AddClasses(publicOnly:false)
                .UsingRegistrationStrategy(registrationStrategy: RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime();
        });
       
        return services;
    }
}
