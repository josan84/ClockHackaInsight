using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ClockHackaInsight.Backend.Controllers;
using ClockHackaInsight.Backend.Enums;
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
        const int SECURITY_COUNTER = 5;

        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int iterations = 1;

            while (!stoppingToken.IsCancellationRequested)
            {
                if (iterations == SECURITY_COUNTER)
                {
                    break;
                }

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                var motivationalQuoteService = new MotivationalQuotesService(new DocumentDBRepository<MotivationalQuote>("Quotes"));

                var messageBroadcasterService = new MessageBroadcastService();

                var pollingFrequencyHelper = new PollingFrequencyHelper();

                IList<PollingResponse> pollingResponses = pollingFrequencyHelper.GetUsersToMessage();

                foreach (var userData in pollingResponses)
                {
                    var randomQuote = motivationalQuoteService.GetRandomQuote();

                    MotivationalQuote quote = randomQuote.Result;

                    var userService = new UserService(new DocumentDBRepository<User>("Users"));

                    var now = DateTime.Now;

                  //  bool mustSend = false;

                    var user = new User();

                    //if (user.Frequency.Frequency == MessageFrequency.Day)
                    //{
                    //    if (now.Subtract(user.Frequency.LastMessaged) <= TimeSpan.FromDays(-1))
                    //    {
                    //        mustSend = true;
                    //    }
                    //}
                    //else if (user.Frequency.Frequency == MessageFrequency.Hour)
                    //{
                    //    if (now.Subtract(user.Frequency.LastMessaged) <= TimeSpan.FromHours(-1))
                    //    {
                    //        mustSend = true;
                    //    }
                    //}
                    //else if (user.Frequency.Frequency == MessageFrequency.Minute)
                    //{
                    //    if (now.Subtract(user.Frequency.LastMessaged) <= TimeSpan.FromMinutes(-1))
                    //    {
                    //        mustSend = true;
                    //    }
                    //}

                    //if (mustSend)
                    //{
                        messageBroadcasterService.SendMessage(userData.Name, userData.Number, quote.Quote);
                   // }

                    var userFrequency = new UserFrequency
                    {
                        LastMessaged = now
                    };

                    user.Id = userData.Id;
                    user.Name = userData.Name;
                    user.Number = userData.Number;

                    user.Frequency = userFrequency;

                   // await userService.UpdateUser(userData.Id, user);
                }

                await Task.Delay(3000, stoppingToken);

                iterations++;
            }
        }
    }
}
