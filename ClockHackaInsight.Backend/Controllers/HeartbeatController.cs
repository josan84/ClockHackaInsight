using ClockHackaInsight.Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClockHackaInsight.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeartbeatController : ControllerBase
    {
        public HeartbeatController()
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HeartbeatData heartbeat)
        {
            return Ok(true);
        }
    }
}
