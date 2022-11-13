using Zidy.Domain.Interfaces;
using Zidy.Services;

namespace Zidy.Dependencies
{
    public static class ServiceDependency
    {
        public static void AddServicesDependency(this IServiceCollection services)
        {
            services.AddTransient<IServiceCustomer, CustomerService>();
        }
    }
}
