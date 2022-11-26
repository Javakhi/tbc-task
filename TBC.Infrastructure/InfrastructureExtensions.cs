using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TBC.Infrastructure.DbContexts;

namespace TBC.Infrastructure
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();


            services.AddDbContext<PersonDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


         



            return services;
        }
    }
}