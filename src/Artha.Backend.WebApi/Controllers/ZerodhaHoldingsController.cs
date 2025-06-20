using Microsoft.AspNetCore.Mvc;
using Artha.Backend.Services.Interface;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Artha.Backend.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZerodhaHoldingsController : ControllerBase
    {
        private readonly IZerodhaHoldingsService _service;
        private readonly ILogger<ZerodhaHoldingsController> _logger;

        public ZerodhaHoldingsController(
            IZerodhaHoldingsService service,
            ILogger<ZerodhaHoldingsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost("insert-holdings")]
        public async Task<IActionResult> InsertHoldings()
        {
            try
            {
                _logger.LogInformation("Inserting Zerodha holdings via service.");
                var result = await _service.InsertZerodhaHoldingsAsync();
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inserting Zerodha holdings");
                return StatusCode(500, new { error = "An error occurred while inserting holdings.", details = ex.Message });
            }
        }
    }
}
