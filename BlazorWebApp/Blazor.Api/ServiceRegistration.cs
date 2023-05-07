using Blazor.BL.IService;
using Blazor.BL.Service;
using Blazor.DAL.IRepository;
using Blazor.DAL.Repository;

namespace Blazor.Api
{
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ISubElementService, SubElementService>();
            services.AddScoped<ISubElementRepository, SubElementRepository>();
            services.AddScoped<IWindowService, WindowService>();
            services.AddScoped<IWindowRepository, WindowRepository>();
            // Add any additional services you need here
        }
    }
}
