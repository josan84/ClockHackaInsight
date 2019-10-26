using ClockHackaInsight.Backend.Enums;
using ClockHackaInsight.Backend.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClockHackaInsight.Backend.TestData
{
    public static class UserFrequencyTestData
    {
        public static IEnumerable<User> GetUsers()
        {
            return new List<User>()
            {
                new User()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "joshua",
                    Number = "07952316758",
                    Frequency = new UserFrequency()
                    {
                        LastMessaged = new DateTime(),
                        Frequency = MessageFrequency.Day
                    }
                },
                new User()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "jacob",
                    Number = "12345",
                    Frequency = new UserFrequency()
                    {
                        LastMessaged = new DateTime(),
                        Frequency = MessageFrequency.Day
                    }
                },
                new User()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "toby",
                    Number = "987654",
                    Frequency = new UserFrequency()
                    {
                        LastMessaged = new DateTime(),
                        Frequency = MessageFrequency.Day
                    }
                },
                new User()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "jose",
                    Number = "68309298",
                    Frequency = new UserFrequency()
                    {
                        LastMessaged = new DateTime(),
                        Frequency = MessageFrequency.Day
                    }
                },
            };
        }
    }
}
