using ClockHackaInsight.Backend.Helpers;
using ClockHackaInsight.Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClockHackaInsight.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeartbeatController : ControllerBase
    {
        private readonly IHeartbeatHelper _helper;

        public HeartbeatController(IHeartbeatHelper helper)
        {
            _helper = helper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HeartbeatData heartbeat)
        {
            return Ok(await _helper.ExecuteHeartbeatProtocol(heartbeat));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]string userId)
        {
            return Ok()
        }
    }
}
