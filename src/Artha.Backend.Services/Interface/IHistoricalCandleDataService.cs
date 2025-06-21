using System.Collections.Generic;
using System.Threading.Tasks;
using Artha.Backend.Shared.Dto;

namespace Artha.Backend.Services.Interface
{
    /// <summary>
    /// Service interface for fetching historical candle data.
    /// </summary>
    public interface IHistoricalCandleDataService
    {
        /// <summary>
        /// Fetches historical candle data for a given symbol and exchange within a date range.
        /// </summary>
        /// <param name="symbol">The trading symbol.</param>
        /// <param name="exchange">The exchange.</param>
        /// <param name="from">The start date (as string).</param>
        /// <param name="to">The end date (as string).</param>
        /// <returns>List of historical candle data DTOs.</returns>
        Task<List<HistoricalCandleDataDto>> GetHistoricalCandleDataAsync(string symbol, string exchange, string from, string to);
    }
}
