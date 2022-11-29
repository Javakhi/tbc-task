using Microsoft.Extensions.DependencyInjection;
using System.Net;
using MediatR;
using TBC.Application.Queries;
using System.Reflection;

namespace TBC.Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
           // services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            var assembly = Assembly.GetExecutingAssembly();

            return services.AddMediatR(assembly);
        }

    }
}