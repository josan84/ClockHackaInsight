using ClockHackaInsight.Backend.Models;
using System.Collections.Generic;

namespace ClockHackaInsight.Backend.Helpers
{
    public interface IPollingFrequencyHelper
    {
        List<PollingResponse> GetUsersToMessage();
    }
}
