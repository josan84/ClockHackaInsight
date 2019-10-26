using ClockHackaInsight.Backend.Models;
using ClockHackaInsight.Backend.Services;
using ClockHackInsight.Backend;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ClockHackaInsight.Backend
{
    public class HeartbeatWorker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IUserService userService;
        private readonly IMessageBroadcastService messageBroadcastService;

        public HeartbeatWorker(IUserService userService, IMessageBroadcastService messageBroadcastService)
        {
            this.userService = userService;
            this.messageBroadcastService = messageBroadcastService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int iterations = 0;

            while (!stoppingToken.IsCancellationRequested)
            {
                var users = await userService.GetAllUsers(); //TODO: Get All Users

                foreach (var user in users)
                {
                    if (user.AwaitingResponse && user.BpmMessageSentTime + new TimeSpan(0, 10, 0) > DateTime.Now)
                    {
                        messageBroadcastService.SendMessage(user.EmergencyContact.Name, user.EmergencyContact.Number, $"We have had an alert from {user.Name}");
                    }
                }

                await Task.Delay(3000, stoppingToken);

                iterations++;
            }

        }
    }
}
