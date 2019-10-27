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
    public class HeartbeatWorker : IHostedService
    {
        private readonly ILogger<MotivationalWorker> _logger;
        private readonly IUserService userService;
        private readonly IMessageBroadcastService messageBroadcastService;
        private Timer _timer;

        public HeartbeatWorker(IUserService userService, IMessageBroadcastService messageBroadcastService)
        {
            this.userService = userService;
            this.messageBroadcastService = messageBroadcastService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(MessageEmergencyContact, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        private async void MessageEmergencyContact(object state)
        {
            var users = await userService.GetAllUsers();

            foreach (var user in users)
            {
                if (user.AwaitingResponse && ((user.BpmMessageSentTime + new TimeSpan(0, 0, 10)) > DateTime.Now))
                {
                    messageBroadcastService.SendMessage(user.EmergencyContact.Name, user.EmergencyContact.Number, $"We noticed {user.Name} has an unusually high heartrate. Please call them to make sure everything is ok on {user.Number}");
                    
                    user.BpmMessageSentTime = null;
                    user.AwaitingResponse = false;

                    var callback = userService.SaveUser(user.Id, user);
                }
            }
        }
    }
}
