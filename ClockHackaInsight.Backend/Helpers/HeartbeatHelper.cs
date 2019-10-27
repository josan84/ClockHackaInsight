﻿using System;
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
                var user = await userService.GetUserById(heartbeat.UserId);
                messageBroadcastService.SendMessage(user.Name, user.Number, "We noticed you are particuarly stressed. Reply OK if it is a false alarm");
                user.AwaitingResponse = true;
                user.BpmMessageSentTime = DateTime.Now;
                var callback = await userService.SaveUser(user.Id, user);
            }

            return true;
        }
    }
}
