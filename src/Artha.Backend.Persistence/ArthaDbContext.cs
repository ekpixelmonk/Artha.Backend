using Artha.Backend.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Artha.Backend.Persistence
{
    public class ArthaDbContext : DbContext
    {
        public ArthaDbContext(DbContextOptions<ArthaDbContext> options) : base(options) { }

        public DbSet<ZerodhaConfig> ZerodhaConfig { get; set; }
        public DbSet<ZerodhaTradeableInstrumentEntity> ZerodhaTradeableInstruments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure ZerodhaConfig entity
            modelBuilder.Entity<ZerodhaConfig>()
                .HasIndex(z => z.ID)
                .IsUnique();
            modelBuilder.Entity<ZerodhaConfig>()
                .Property(z => z.ID)
                .HasDefaultValue(1);

            // Apply configuration for ZerodhaTradeableInstrumentEntity
            modelBuilder.ApplyConfiguration(new EntityConfiguration.ZerodhaTradeableInstrumentConfiguration());
        }
    }
}
