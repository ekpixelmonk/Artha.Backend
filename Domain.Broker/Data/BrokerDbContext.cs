// Domain.Broker/Data/BrokerDbContext.cs

using Domain.Broker.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Domain.Broker.Data;

public class BrokerDbContext(DbContextOptions<BrokerDbContext> options) : DbContext(options)
{
    // The DbSet property name 'ZerodhaConfigs' will be the default table name.
    public DbSet<ZerodhaConfig> ZerodhaConfigs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}