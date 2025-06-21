using Microsoft.AspNetCore.Mvc;
using Artha.Backend.Services.Interface;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Artha.Backend.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistoricalCandleDataController : ControllerBase
    {
        private readonly IHistoricalCandleDataService _service;
        private readonly ILogger<HistoricalCandleDataController> _logger;

        public HistoricalCandleDataController(IHistoricalCandleDataService service, ILogger<HistoricalCandleDataController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("get-candles")]
        public async Task<IActionResult> GetCandles([FromQuery] string symbol, [FromQuery] string exchange, [FromQuery] string from, [FromQuery] string to)
        {
            try
            {
                _logger.LogInformation("Fetching historical candle data for symbol: {symbol}, exchange: {exchange}, from: {from}, to: {to}", symbol, exchange, from, to);
                var result = await _service.GetHistoricalCandleDataAsync(symbol, exchange, from, to);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching historical candle data for symbol: {symbol}, exchange: {exchange}, from: {from}, to: {to}", symbol, exchange, from, to);
                return StatusCode(500, new { error = "An error occurred while fetching historical candle data.", details = ex.Message });
            }
        }
    }
}
