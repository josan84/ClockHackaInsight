using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ClockHackaInsight.Backend.Helpers;
using ClockHackaInsight.Backend.Models;
using ClockHackaInsight.Backend.Repositories;
using ClockHackaInsight.Backend.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ClockHackInsight.Backend
{
    public class Worker : BackgroundService
    {
        const int SECURITY_COUNTER = 1;

        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int iterations = 0;

            while (!stoppingToken.IsCancellationRequested)
            {
                if (iterations == SECURITY_COUNTER)
                {
                    break;
                }

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                var motivationalQuoteService = new MotivationalQuotesService(new DocumentDBRepository<MotivationalQuote>("Quotes"));

                var messageBroadcasterService = new MessageBroadcastService();

                var userService = new UserService(new DocumentDBRepository<User>("Users"));

                var users = await userService.GetAllUsers();

                foreach (var user in users)
                {
                    MotivationalQuote randomQuote = motivationalQuoteService.GetRandomQuote().Result;

                    var now = DateTime.Now;

                    messageBroadcasterService.SendMessage(user.Name, user.Number, randomQuote.Quote);

                    var userFrequency = new UserFrequency
                    {
                        LastMessaged = now,
                        Frequency = user.Frequency.Frequency
                    };

                    user.Frequency = userFrequency;

                    await userService.UpdateUser(user.Id, user);
                }

                await Task.Delay(3000, stoppingToken);

                iterations++;
            }
        }
    }
}
