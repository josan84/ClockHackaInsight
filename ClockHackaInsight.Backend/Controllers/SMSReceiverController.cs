using ClockHackaInsight.Backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClockHackaInsight.Backend.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class SMSReceiverController : ControllerBase
    //{
    //    private readonly IUserService _userService;

    //    public SMSReceiverController(IUserService userService)
    //    {
    //        _userService = userService;
    //    }

    //    [HttpPost]
    //    public async Task<IActionResult> Post(
    //        [FromQuery] string to, [FromQuery] string from,
    //        [FromQuery] string keyword, [FromQuery] string id, 
    //        [FromQuery] string content)
    //    {
    //        try
    //        {
    //            if (from.StartsWith("44"))
    //                from = "0" + from[1..];

    //            var user = await _userService.GetUserByNumber(from);
    //            if (user.Frequency == null)
    //                user.Frequency = new Models.UserFrequency();

    //            user.Frequency.Frequency = Enums.MessageFrequency.Never;

    //            await _userService.SaveUser(user.Id, user);
    //        }
    //        finally
    //        {
    //        }
    //        return Ok(true);
    //    }
    //}
}
