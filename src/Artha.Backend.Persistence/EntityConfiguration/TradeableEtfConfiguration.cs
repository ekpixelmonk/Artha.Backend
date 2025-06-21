using Artha.Backend.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artha.Backend.Persistence.EntityConfiguration
{
    public class TradeableEtfConfiguration : IEntityTypeConfiguration<TradeableEtfEntity>
    {
        public void Configure(EntityTypeBuilder<TradeableEtfEntity> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(e => e.Symbol).HasMaxLength(250).IsRequired();
            builder.Property(e => e.Exchange).HasMaxLength(100).IsRequired();
            builder.HasIndex(e => new { e.Symbol, e.Exchange }).IsUnique();
        }
    }
}
