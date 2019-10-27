using ClockHackaInsight.Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClockHackaInsight.Backend.Services
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetEvents();
    }
}