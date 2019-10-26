using System;
using System.Collections.Generic;
using System.Linq;
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

                var randomQuote = motivationalQuoteService.GetRandomQuote();

                MotivationalQuote quote = randomQuote.Result;

                var messageBroadcasterService = new MessageBroadcastService();

                messageBroadcasterService.SendMessage("", "", quote.Quote);

                await Task.Delay(3000, stoppingToken);
            }
        }
    }
}
