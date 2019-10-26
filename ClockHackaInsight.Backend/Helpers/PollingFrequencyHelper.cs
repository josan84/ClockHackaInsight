using ClockHackaInsight.Backend.Enums;
using ClockHackaInsight.Backend.Models;
using ClockHackaInsight.Backend.TestData;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClockHackaInsight.Backend.Helpers
{
    public class PollingFrequencyHelper
    {
        public List<PollingResponse> GetUsersToMessage()
        {
            var usersToMessage = new List<PollingResponse>();
            var users = UserFrequencyTestData.GetUsers();

            foreach (var user in users)
            {
                var interval = GetFrequencyTimeSpan(user.Frequency.Frequency);
                if (user.Frequency.LastMessaged.Add(interval) > DateTime.Now)
                {
                    usersToMessage.Add(new PollingResponse()
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Number = user.Number
                    });
                }
            }

            return usersToMessage;
        }

        private TimeSpan GetFrequencyTimeSpan(MessageFrequency frequency)
        {
            switch (frequency)
            {
                case MessageFrequency.Minute:
                    return new TimeSpan(0, 1, 0);
                case MessageFrequency.Hour:
                    return new TimeSpan(1, 0, 0);
                case MessageFrequency.Day:
                    return new TimeSpan(1, 0, 0, 0);
                default:
                    return new TimeSpan();
            }
        }

    }
}
