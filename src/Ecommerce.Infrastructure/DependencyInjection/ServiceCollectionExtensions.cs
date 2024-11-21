using Ecommerce.Domain.Repositories.Interfaces;
using Ecommerce.Infrastructure.DataAccess;
using Ecommerce.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<EcommerceDbContext>(options => options.UseInMemoryDatabase("EcommerceDb"));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();

            return services;
        }
    }
}
