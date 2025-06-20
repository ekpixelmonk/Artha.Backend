using Microsoft.AspNetCore.Mvc;
using Artha.Backend.Services.Interface;
using Artha.Backend.Shared.Dto;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Artha.Backend.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZerodhaTradeableInstrumentController : ControllerBase
    {
        private readonly IZerodhaTradeableInstrumentService _service;
        private readonly ILogger<ZerodhaTradeableInstrumentController> _logger;

        public ZerodhaTradeableInstrumentController(
            IZerodhaTradeableInstrumentService service,
            ILogger<ZerodhaTradeableInstrumentController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost("insert-instruments")]
        public async Task<IActionResult> InsertInstruments()
        {
            try
            {
                var result = await _service.InsertZerodhaTradeableInstrumentsAsync();
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inserting Zerodha tradeable instruments");
                return StatusCode(500, new { error = "An error occurred while inserting instruments.", details = ex.Message });
            }
        }

        [HttpGet("get-instrument")]
        public async Task<IActionResult> GetInstrument([FromQuery] string tradingsymbol, [FromQuery] string exchange)
        {
            try
            {
                _logger.LogInformation("Fetching instrument for tradingsymbol: {tradingsymbol}, exchange: {exchange}", tradingsymbol, exchange);
                var instrument = await _service.GetInstrumentByTradingSymbolAndExchangeAsync(tradingsymbol, exchange);
                if (instrument == null)
                {
                    _logger.LogWarning("Instrument not found for tradingsymbol: {tradingsymbol}, exchange: {exchange}", tradingsymbol, exchange);
                    return NotFound();
                }
                return Ok(instrument);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching instrument for tradingsymbol: {tradingsymbol}, exchange: {exchange}", tradingsymbol, exchange);
                return StatusCode(500, new { error = "An error occurred while fetching the instrument.", details = ex.Message });
            }
        }
    }
}
