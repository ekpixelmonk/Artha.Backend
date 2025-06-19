using Artha.Backend.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artha.Backend.Persistence.EntityConfiguration
{
    public class ZerodhaTradeableInstrumentConfiguration : IEntityTypeConfiguration<ZerodhaTradeableInstrumentEntity>
    {
        public void Configure(EntityTypeBuilder<ZerodhaTradeableInstrumentEntity> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(e => e.instrument_token).HasMaxLength(50);
            builder.Property(e => e.exchange_token).HasMaxLength(50);
            builder.Property(e => e.tradingsymbol).HasMaxLength(250).IsRequired();
            builder.Property(e => e.name).HasMaxLength(500);
            builder.Property(e => e.last_price).HasColumnType("decimal(18,2)");
            builder.Property(e => e.expiry).HasMaxLength(50);
            builder.Property(e => e.strike).HasColumnType("decimal(18,2)");
            builder.Property(e => e.tick_size).HasColumnType("real");
            builder.Property(e => e.lot_size);
            builder.Property(e => e.instrument_type).HasMaxLength(25);
            builder.Property(e => e.segment).HasMaxLength(100);
            builder.Property(e => e.exchange).HasMaxLength(50).IsRequired();
            builder.HasIndex(e => new { e.exchange, e.tradingsymbol }).IsUnique();
        }
    }
}
