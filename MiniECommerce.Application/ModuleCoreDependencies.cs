

using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MiniECommerce.Application.Behaviors;

namespace MiniECommerce.Application
{
    public static class ModuleCoreDependencies
    {
        public static void AddModuleCoreDependencies(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ModuleCoreDependencies).Assembly));
            services.AddValidatorsFromAssembly(typeof(ModuleCoreDependencies).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
