using Microsoft.Extensions.DependencyInjection;
using MiniECommerce.Service.Implementation;
using MiniECommerce.Service.Interfaces;

namespace MiniECommerce.Service
{
    public static class ModuleServiceDependencies
    {
        public static void AddModuleServicesDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}
