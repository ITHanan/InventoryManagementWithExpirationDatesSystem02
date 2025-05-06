using ApplicationLayer.ACommen.Behaviers;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            // Register MediatR handlers
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
            // Register AutoMapper profiles
            services.AddAutoMapper(assembly);
            // Register all FluentValidation validators in the assembly
            services.AddValidatorsFromAssembly(assembly);

            // Register MediatR pipeline behaviors
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

            

            return services;
        }
    }
}
