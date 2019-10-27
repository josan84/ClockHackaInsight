using ClockHackaInsight.Backend.Helpers;
using ClockHackaInsight.Backend.Models;
using ClockHackaInsight.Backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClockHackaInsight.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeartbeatController : ControllerBase
    {
        private readonly IHeartbeatHelper _helper;
        private readonly IUserService _userService;

        public HeartbeatController(IHeartbeatHelper helper, IUserService userService)
        {
            _userService = userService;
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
            return Ok(await _userService.GetUserById(userId));
        }
    }
}
