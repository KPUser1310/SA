using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SmartAttend.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());
           // services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyMarker).Assembly);
            });

            services.AddSBTopics(configuration);
            services.AddSBTopicSubscriptions(configuration);
            return services;
        }

        private static void AddSBTopics(this IServiceCollection services, IConfiguration config)
        {

        }

        private static void AddSBTopicSubscriptions(this IServiceCollection services, IConfiguration config)
        {
        }     
    }
}
