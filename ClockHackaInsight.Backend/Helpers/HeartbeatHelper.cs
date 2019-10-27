using System.Text;
using System;
using System.Threading.Tasks;
using ClockHackaInsight.Backend.Models;
using ClockHackaInsight.Backend.Services;
using System.Collections.Generic;
using System.Linq;

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
            var user = await userService.GetUserById(heartbeat.UserId);
            var history = user.HeartbeatHistory?.ToList() ?? new List<HeartbeatHistory>();
            history.Add(new HeartbeatHistory { AverageBpm = heartbeat.AverageBpm, DateTime = DateTime.Now });
            user.HeartbeatHistory = history;

            if (heartbeat.AverageBpm > 100 && heartbeat.IsOutlyingStatus)
            {
                var builder = new StringBuilder();
                builder.AppendLine("We noticed you are particuarly stressed.");
                builder.AppendLine("If false alarm reply OK.");
                builder.AppendLine("If you need advice reply HELP.");
                messageBroadcastService.SendMessage(user.Name, user.Number, builder.ToString());
                user.AwaitingResponse = true;
                user.BpmMessageSentTime = DateTime.Now;
            }

            await userService.SaveUser(user.Id, user);


            return true;
        }
    }
}
