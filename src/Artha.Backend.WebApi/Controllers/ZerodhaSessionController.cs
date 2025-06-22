using Microsoft.AspNetCore.Mvc;
using Artha.Backend.Services.Interface;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Artha.Backend.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZerodhaSessionController : ControllerBase
    {
        private readonly IKiteSessionService _kiteSessionService;
        private readonly ILogger<ZerodhaSessionController> _logger;

        public ZerodhaSessionController(IKiteSessionService kiteSessionService, ILogger<ZerodhaSessionController> logger)
        {
            _kiteSessionService = kiteSessionService;
            _logger = logger;
        }

        [HttpGet("get-login-url")]
        public async Task<IActionResult> GetLoginUrl()
        {
            try
            {
                var loginUrl = await _kiteSessionService.InitializeKiteSessionAndGetLoginUrlAsync();
                return Ok(new { loginUrl });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting Kite login URL");
                return StatusCode(500, new { error = "Failed to get Kite login URL.", details = ex.Message });
            }
        }

        [HttpPost("establish-session")]
        public async Task<IActionResult> EstablishSession([FromQuery] string requestToken)
        {
            try
            {
                var result = await _kiteSessionService.GenerateKiteUserSessionAsync(requestToken);
                if (result)
                {
                    return Ok(new { message = "Kite session established successfully." });
                }
                else
                {
                    return BadRequest(new { error = "Failed to establish Kite session." });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error establishing Kite session");
                return StatusCode(500, new { error = "Failed to establish Kite session.", details = ex.Message });
            }
        }
    }
}
