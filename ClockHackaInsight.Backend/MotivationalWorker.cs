using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ClockHackaInsight.Backend.Enums;
using ClockHackaInsight.Backend.Helpers;
using ClockHackaInsight.Backend.Models;
using ClockHackaInsight.Backend.Repositories;
using ClockHackaInsight.Backend.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ClockHackInsight.Backend
{
    public class MotivationalWorker : IHostedService
    {
        const int SECURITY_COUNTER = 1;

        private readonly ILogger<MotivationalWorker> _logger;

        private readonly IMotivationalQuotesService _motivationalQuotesService;
        private readonly IMessageBroadcastService _messageBroadcastService;
        private readonly IUserService _userService;

        private Timer _timer;
        private int _interations = 0;

        public MotivationalWorker(ILogger<MotivationalWorker> logger, IMotivationalQuotesService motivationalQuotesService, IMessageBroadcastService messageBroadcastService, IUserService userService)
        {
            _logger = logger;

            _motivationalQuotesService = motivationalQuotesService;
            _messageBroadcastService = messageBroadcastService;
            _userService = userService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DiscoverMotivationals, null, TimeSpan.Zero, TimeSpan.FromMinutes(10));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private async void DiscoverMotivationals(object state)
        {
            if (_interations == SECURITY_COUNTER)
            {
                return;
            }

            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            var users = await _userService.GetAllUsers();

            foreach (var user in users)
            {
                MotivationalQuote randomQuote = _motivationalQuotesService.GetRandomQuote().Result;

                var now = DateTime.Now;

                bool mustSend = false;

                if (user.Frequency.Frequency == MessageFrequency.Day)
                {
                    if (now.Subtract(user.Frequency.LastMessaged) > TimeSpan.FromDays(-1))
                    {
                        mustSend = true;
                    }
                }
                else if (user.Frequency.Frequency == MessageFrequency.Hour)
                {
                    if (now.Subtract(user.Frequency.LastMessaged) > TimeSpan.FromHours(-1))
                    {
                        mustSend = true;
                    }
                }
                else if (user.Frequency.Frequency == MessageFrequency.Minute)
                {
                    if (now.Subtract(user.Frequency.LastMessaged) > TimeSpan.FromMinutes(-1))
                    {
                        mustSend = true;
                    }
                }

                if (mustSend)
                {
                    _messageBroadcastService.SendMessage(user.Name, user.Number, $"{randomQuote.Quote}. To stop receiving these messages reply STOP.");
                }

                var userFrequency = new UserFrequency
                {
                    LastMessaged = now,
                    Frequency = user.Frequency.Frequency
                };

                user.Frequency = userFrequency;

                await _userService.UpdateUser(user.Id, user);
            }

            _interations++;

            return;
        }
    }
}
