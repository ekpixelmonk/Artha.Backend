namespace Artha.Backend.Domain.Entity
{
    public class TradeableEtfEntity
    {
        public int ID { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string Exchange { get; set; } = string.Empty;
    }
}
