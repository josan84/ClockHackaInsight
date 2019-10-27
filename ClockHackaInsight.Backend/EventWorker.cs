using ClockHackaInsight.Backend.Services;
using ClockHackInsight.Backend;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ClockHackaInsight.Backend
{
    public class EventWorker : IHostedService
    {
        private readonly ILogger<EventWorker> _logger;
        private readonly IEventService _eventsService;
        private readonly IMessageBroadcastService _messageBroadcastService;
        private readonly IUserService _usersService;

        private Timer _timer;

        public EventWorker(ILogger<EventWorker> logger, IEventService eventsService, IMessageBroadcastService messageBroadcastService, IUserService userService)
        {
            _logger = logger;
            _eventsService = eventsService;
            _messageBroadcastService = messageBroadcastService;
            _usersService = userService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DiscoverEvents, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private void DiscoverEvents(object state)
        {
            var events = _eventsService.GetEvents().Result;

            var users = _usersService.GetAllUsers().Result;

            foreach (var ev in events)
            {
                string eventMessage = $"{ev.Content}. Date and Time: {ev.EventDateTime}";

                foreach (var user in users)
                {
                    // For demo
                    if (user.Name.ToLower() == "jose")
                    {


                        if (user.EventSocialEnabled && ev.EventType == Models.EventType.Social
                           && ev.EventDateTime > DateTime.Now)
                        {
                            _messageBroadcastService.SendMessage(user.Name, user.Number, eventMessage);
                        }
                        else if (user.EventTherapyEnabled && ev.EventType == Models.EventType.Therapy
                           && ev.EventDateTime > DateTime.Now)
                        {
                            _messageBroadcastService.SendMessage(user.Name, user.Number, eventMessage);
                        }
                        else if (user.EventConferenceEnabled && ev.EventType == Models.EventType.Conference
                           && ev.EventDateTime > DateTime.Now)
                        {
                            _messageBroadcastService.SendMessage(user.Name, user.Number, eventMessage);
                        }
                        else if (user.EventSportEnabled && ev.EventType == Models.EventType.Sport
                          && ev.EventDateTime > DateTime.Now)
                        {
                            _messageBroadcastService.SendMessage(user.Name, user.Number, eventMessage);
                        }
                    }
                }
            }
        }
    }
}

