using Microsoft.AspNetCore.Mvc;
using Artha.Backend.Services.Interface;
using Artha.Backend.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Artha.Backend.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TradeableEtfController : ControllerBase
    {
        private readonly ITradeableEtfService _service;
        private readonly ILogger<TradeableEtfController> _logger;

        public TradeableEtfController(ITradeableEtfService service, ILogger<TradeableEtfController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("get-etf")]
        public async Task<IActionResult> GetEtf([FromQuery] string symbol, [FromQuery] string exchange)
        {
            try
            {
                _logger.LogInformation("Fetching ETF for symbol: {symbol}, exchange: {exchange}", symbol, exchange);
                var etf = await _service.GetEtfBySymbolAndExchangeAsync(symbol, exchange);
                if (etf == null)
                {
                    _logger.LogWarning("ETF not found for symbol: {symbol}, exchange: {exchange}", symbol, exchange);
                    return NotFound();
                }
                return Ok(etf);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching ETF for symbol: {symbol}, exchange: {exchange}", symbol, exchange);
                return StatusCode(500, new { error = "An error occurred while fetching the ETF.", details = ex.Message });
            }
        }

        [HttpPost("insert-etfs")]
        public async Task<IActionResult> InsertEtfs([FromBody] List<TradeableEtfDto> etfs)
        {
            if (etfs == null || etfs.Count == 0)
            {
                _logger.LogWarning("InsertEtfs called with empty ETF list.");
                return BadRequest(new { error = "ETF list cannot be empty." });
            }
            try
            {
                _logger.LogInformation("Inserting {Count} tradeable ETFs.", etfs.Count);
                var result = await _service.InsertTradeableEtfsAsync(etfs);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inserting tradeable ETFs");
                return StatusCode(500, new { error = "An error occurred while inserting ETFs.", details = ex.Message });
            }
        }
    }
}
