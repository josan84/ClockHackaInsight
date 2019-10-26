using ClockHackaInsight.Backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClockHackaInsight.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSReceiverController : ControllerBase
    {
        private readonly IUserService _userService;

        public SMSReceiverController(IUserService userService)
        {
            _userService = userService;
        }

        //[HttpPost]
        //public async Task<IActionResult> Post(
        //    [FromQuery] string to, [FromQuery] string from,
        //    [FromQuery] string keyword, [FromQuery] string id, 
        //    [FromQuery] string content)
        //{
        //    if (from.StartsWith("0"))
        //        from = from.Substring(0,1)
        //            from.Replace("0", "44");
        //    var user = _userService.GetUserByNumber(from);

        //    return Ok(true);
        //}
    }
}
