using ClockHackaInsight.Backend.Enums;
using ClockHackaInsight.Backend.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClockHackaInsight.Backend.TestData
{
    public static class UserFrequencyTestData
    {
        const string JoshNumber = "447952316758";
        const string JacobNumber = "447507100781";
        const string TobyNumber = "447498330042";
        const string JoseNumber = "447761389099";

        public static IEnumerable<User> GetUsers()
        {
            return new List<User>()
            {
                new User()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "joshua",
                    Number = JoshNumber,
                    Frequency = new UserFrequency()
                    {
                        LastMessaged = DateTime.Now.AddMinutes(-2),
                        Frequency = MessageFrequency.Minute
                    }
                },
                new User()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "jacob",
                    Number = JacobNumber,
                    Frequency = new UserFrequency()
                    {
                        LastMessaged = DateTime.Now.AddDays(-2),
                        Frequency = MessageFrequency.Day
                    }
                },
                new User()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "toby",
                    Number = TobyNumber,
                    Frequency = new UserFrequency()
                    {
                        LastMessaged = DateTime.Now,
                        Frequency = MessageFrequency.Day
                    }
                },
                new User()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "jose",
                    Number = JoseNumber,
                    Frequency = new UserFrequency()
                    {
                        LastMessaged = DateTime.Now.AddHours(-2),
                        Frequency = MessageFrequency.Hour
                    }
                },
            };
        }
    }
}
