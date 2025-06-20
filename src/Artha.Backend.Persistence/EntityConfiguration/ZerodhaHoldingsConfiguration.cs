using Artha.Backend.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artha.Backend.Persistence.EntityConfiguration
{
    public class ZerodhaHoldingsConfiguration : IEntityTypeConfiguration<ZerodhaHoldingsEntity>
    {
        public void Configure(EntityTypeBuilder<ZerodhaHoldingsEntity> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(e => e.tradingsymbol).HasMaxLength(50).IsRequired();
            builder.Property(e => e.exchange).HasMaxLength(50).IsRequired();
            // Add unique index for tradingsymbol + exchange
            builder.HasIndex(e => new { e.tradingsymbol, e.exchange }).IsUnique();
            builder.Property(e => e.instrument_token);
            builder.Property(e => e.isin).HasMaxLength(200);
            builder.Property(e => e.t1_quantity);
            builder.Property(e => e.realised_quantity);
            builder.Property(e => e.quantity);
            builder.Property(e => e.used_quantity);
            builder.Property(e => e.authorised_quantity);
            builder.Property(e => e.opening_quantity);
            builder.Property(e => e.authorised_date).HasMaxLength(50);
            builder.Property(e => e.price).HasColumnType("decimal(18,2)");
            builder.Property(e => e.average_price).HasColumnType("decimal(18,2)");
            builder.Property(e => e.last_price).HasColumnType("decimal(18,2)");
            builder.Property(e => e.close_price).HasColumnType("decimal(18,2)");
            builder.Property(e => e.pnl).HasColumnType("real");
            builder.Property(e => e.day_change).HasColumnType("real");
            builder.Property(e => e.day_change_percentage).HasColumnType("real");
            builder.Property(e => e.product).HasMaxLength(100);
            builder.Property(e => e.collateral_quantity);
            builder.Property(e => e.collateral_type).HasMaxLength(100);
            builder.Property(e => e.discrepancy);
        }
    }
}
