using System.Text;
using System.Threading.Tasks;
using ClockHackaInsight.Backend.Models;
using ClockHackaInsight.Backend.Services;

namespace ClockHackaInsight.Backend.Helpers
{
    public class HeartbeatHelper : IHeartbeatHelper
    {
        private readonly IMessageBroadcastService messageBroadcastService;
        private readonly IUserService userService;

        public HeartbeatHelper(IMessageBroadcastService messageBroadcastService, IUserService userService)
        {
            this.messageBroadcastService = messageBroadcastService;
            this.userService = userService;
        }

        public async Task<bool> ExecuteHeartbeatProtocol(HeartbeatData heartbeat)
        {
            if (heartbeat.AverageBpm > 100 && heartbeat.IsOutlyingStatus)
            {
                var builder = new StringBuilder();
                builder.AppendLine("We noticed you are particuarly stressed.");
                builder.AppendLine("If false alarm reply OK.");
                builder.AppendLine("If you need advice reply HELP.");
                var user = await userService.GetUserById(heartbeat.UserId);
                messageBroadcastService.SendMessage(user.Name, user.Number, builder.ToString());
            }

            return true;
        }
    }
}
