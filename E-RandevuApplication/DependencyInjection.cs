using Microsoft.Extensions.DependencyInjection;

namespace E_RandevuApplication;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration=>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });
        return services;
    }
       
       
}
