using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartAttend.Application.Common.Inferfaces;
using SmartAttend.Application.Interface;
using SmartAttend.Application.Interfaces;
using SmartAttend.Application.Production.Services;
using SmartAttend.Infrastructure.Persistence;
using SmartAttend.Infrastructure.Services;
using SmartAttend.Infrastructure.Services.Notifications;

namespace SmartAttend.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // App configuration provider
            var configProvider = new AppConfigurationsProvider(configuration);

            // Register the concrete ApplicationDbContext
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(
                    configProvider.GetAppDbConnectionString(),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                          .MigrationsHistoryTable("__SmartAttendDbMigrationsHistory")
                );                
            });

            services.AddTransient<IDapperConnectionFactory, DapperContext>();
            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
            services.AddScoped<IPartService, PartService>();
            services.AddScoped<IProductionService, ProductionService>();

            services.AddServiceDependency(configuration);
            // Map interface to concrete DbContext

            return services;
        }

        public static void AddServiceDependency(this IServiceCollection services, IConfiguration config)
        {
            // Register your service
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<INotification, NotificationService>();
        }
    }
}
