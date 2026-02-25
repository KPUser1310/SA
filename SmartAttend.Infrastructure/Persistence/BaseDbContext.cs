using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SmartAttend.Domain.Entities;

namespace SmartAttend.Infrastructure.Persistence
{
    public abstract class BaseDbContext<TContext> : DbContext
        where TContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        protected readonly ILogger<BaseDbContext<TContext>> Logger;

        protected BaseDbContext(
            DbContextOptions<TContext> options,
            ILogger<BaseDbContext<TContext>> logger,
            IConfiguration configuration
        ) : base(options)
        {
            Logger = logger;
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(CoreEventId.RowLimitingOperationWithoutOrderByWarning));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //ApplyBaseEntityConfiguration(builder);
            base.OnModelCreating(builder);
        }

        private static void ApplyBaseEntityConfiguration(ModelBuilder builder)
        {
            foreach (var entityType in builder.Model.GetEntityTypes()
                         .Where(e => typeof(BaseEntity).IsAssignableFrom(e.ClrType)))
            {
                builder.Entity(entityType.ClrType)
                    .Property<DateTime>(nameof(BaseEntity.CreatedAt))
                    .HasDefaultValueSql("now()");

                builder.Entity(entityType.ClrType)
                    .Property<DateTime>(nameof(BaseEntity.LastModifiedAt))
                    .HasDefaultValueSql("now()");
            }
        }
    }
}
