using ClockHackaInsight.Backend.Models;
using ClockHackaInsight.Backend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClockHackaInsight.Backend.Services
{
    public class EventService : IEventService
    {
        private readonly IDocumentDBRepository<Event> _eventRepository;

        public EventService(IDocumentDBRepository<Event> eventRepository)
        {
            this._eventRepository = eventRepository;
        }

        public async Task<IEnumerable<Event>> GetEvents()
        {
           return await this._eventRepository.GetAllItems();
        }
    }
}
