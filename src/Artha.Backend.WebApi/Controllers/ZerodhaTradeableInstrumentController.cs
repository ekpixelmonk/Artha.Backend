using Microsoft.AspNetCore.Mvc;
using Artha.Backend.Services.Interface;
using System;
using System.Threading.Tasks;

namespace Artha.Backend.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZerodhaTradeableInstrumentController : ControllerBase
    {
        private readonly IZerodhaTradeableInstrumentService _service;

        public ZerodhaTradeableInstrumentController(IZerodhaTradeableInstrumentService service)
        {
            _service = service;
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
                // Log exception if needed
                return StatusCode(500, new { error = "An error occurred while inserting instruments.", details = ex.Message });
            }
        }
    }
}
