using System;

namespace Artha.Backend.Domain.Entity
{
    public class ZerodhaHoldingsEntity
    {
        public int ID { get; set; }
        public string tradingsymbol { get; set; } = string.Empty;
        public string exchange { get; set; } = string.Empty;
        public int? instrument_token { get; set; }
        public string? isin { get; set; }
        public int? t1_quantity { get; set; }
        public int? realised_quantity { get; set; }
        public int? quantity { get; set; }
        public int? used_quantity { get; set; }
        public int? authorised_quantity { get; set; }
        public int? opening_quantity { get; set; }
        public string? authorised_date { get; set; }
        public decimal? price { get; set; }
        public decimal? average_price { get; set; }
        public decimal? last_price { get; set; }
        public decimal? close_price { get; set; }
        public float? pnl { get; set; }
        public float? day_change { get; set; }
        public float? day_change_percentage { get; set; }
        public string? product { get; set; }
        public int? collateral_quantity { get; set; }
        public string? collateral_type { get; set; }
        public bool? discrepancy { get; set; }
    }
}
