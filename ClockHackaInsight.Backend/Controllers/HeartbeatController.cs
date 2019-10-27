using ClockHackaInsight.Backend.Helpers;
using ClockHackaInsight.Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
            return Ok(new List<HeartbeatHistory>
            {
                new HeartbeatHistory{AverageBpm = 120, DateTime = DateTime.Now.AddDays(-10)},
                new HeartbeatHistory{AverageBpm = 130, DateTime = DateTime.Now.AddDays(-9)},
                new HeartbeatHistory{AverageBpm = 140, DateTime = DateTime.Now.AddDays(-8)},
                new HeartbeatHistory{AverageBpm = 120, DateTime = DateTime.Now.AddDays(-2)},
                new HeartbeatHistory{AverageBpm = 100, DateTime = DateTime.Now.AddDays(-1)}
            });
        }
    }
}
