using Microsoft.AspNetCore.Mvc;
using Artha.Backend.Services.Interface;
using Artha.Backend.Shared.Dto;

namespace Artha.Backend.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZerodhaConfigController : ControllerBase
    {
        private readonly IZerodhaConfigService _zerodhaConfigService;

        public ZerodhaConfigController(IZerodhaConfigService zerodhaConfigService)
        {
            _zerodhaConfigService = zerodhaConfigService;
        }

        [HttpGet]
        public async Task<ActionResult<ZerodhaConfigDto>> GetZerodhaConfig()
        {
            try
            {
                var config = await _zerodhaConfigService.GetZerodhaConfigAsync();
                return Ok(config);
            }
            catch (Exception ex)
            {
                if (ex.Message == "NotFound")
                    return NotFound();
                // Log exception here if logging is set up
                return StatusCode(500, new { error = "An error occurred while retrieving the Zerodha configuration.", details = ex.Message });
            }
        }
    }
}
