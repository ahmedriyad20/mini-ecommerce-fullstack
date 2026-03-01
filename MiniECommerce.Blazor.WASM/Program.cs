using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MiniECommerce.Blazor.WASM.Services;

namespace MiniECommerce.Blazor.WASM
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            // Configure HttpClient to point to the API
            var apiBaseAddress = builder.Configuration["ApiBaseAddress"];
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseAddress!) });

            // Register services
            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<CustomerService>();
            builder.Services.AddScoped<OrderService>();

            await builder.Build().RunAsync();
        }
    }
}
