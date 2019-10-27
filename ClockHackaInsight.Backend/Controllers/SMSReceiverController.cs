using ClockHackaInsight.Backend.Helpers;
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
        private readonly IPanicHelper _panicHelper;
        private readonly IMessageBroadcastService _messageBroadcastService;

        public SMSReceiverController(
            IUserService userService,
            IPanicHelper panicHelper,
            IMessageBroadcastService messageBroadcastService)
        {
            _userService = userService;
            _messageBroadcastService = messageBroadcastService;
            _panicHelper = panicHelper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery] string to, [FromQuery] string from,
            [FromQuery] string keyword, [FromQuery] string id,
            [FromQuery] string content)
        {
            try
            {
                if (from.StartsWith("44"))
                    from = "0" + from[2..];
                var user = await _userService.GetUserByNumber(from);

                if (content!= null && content.Contains("ADVICE", System.StringComparison.OrdinalIgnoreCase))
                {
                    user.AwaitingResponse = false;
                    await _userService.SaveUser(user.Id, user);
                    var message = _panicHelper.GetPanicInfoMessage();
                    _messageBroadcastService.SendMessage(user.Name, user.Number, message);
                }
                else if(content != null && content.Contains("OK", System.StringComparison.OrdinalIgnoreCase))
                {
                    user.AwaitingResponse = false;
                    await _userService.SaveUser(user.Id, user);
                }
                else if (content != null && content.Contains("HELP", System.StringComparison.OrdinalIgnoreCase))
                {
                    user.AwaitingResponse = false;
                    await _userService.SaveUser(user.Id, user);
                    var message = await _panicHelper.GroundMe(user);
                    _messageBroadcastService.SendMessage(user.Name, user.Number, message);
                }
                else if (content != null && content.Contains("STOP", System.StringComparison.OrdinalIgnoreCase))
                { 
                    if (user.Frequency == null)
                        user.Frequency = new Models.UserFrequency();

                    user.Frequency.Frequency = Enums.MessageFrequency.Never;
                    user.EventConferenceEnabled = false;
                    user.EventSocialEnabled = false;
                    user.EventSportEnabled = false;
                    user.EventTherapyEnabled = false;

                    await _userService.SaveUser(user.Id, user);
                }
            }
            finally
            {
            }
            return Ok(true);
        }
    }
}
