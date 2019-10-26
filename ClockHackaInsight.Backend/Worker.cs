using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ClockHackaInsight.Backend.Controllers;
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
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                var motivationalQuoteService = new MotivationalQuotesService(new DocumentDBRepository<MotivationalQuote>("Quotes"));

                var messageBroadcasterService = new MessageBroadcastService();

                var pollingFrequencyHelper = new PollingFrequencyHelper();

                IList<PollingResponse> pollingResponses = pollingFrequencyHelper.GetUsersToMessage();

                foreach (var userData in pollingResponses)
                {
                    var randomQuote = motivationalQuoteService.GetRandomQuote();

                    MotivationalQuote quote = randomQuote.Result;

                    messageBroadcasterService.SendMessage(userData.Name, userData.Number, quote.Quote);

                    // update last user datetime
                    var usersContoller = new UsersController(new UserService(new DocumentDBRepository<User>("Users")));

                    var user = new User();
                    var userFrequency = new UserFrequency();

                    userFrequency.LastMessaged = DateTime.Now;
                    user.Id = userData.Id;
                    user.Name = userData.Name;
                    user.Number = userData.Number;

                    user.Frequency = userFrequency;

                    usersContoller.Put(userData.Id, user);
                }

                await Task.Delay(3000, stoppingToken);
            }
        }
    }
}
