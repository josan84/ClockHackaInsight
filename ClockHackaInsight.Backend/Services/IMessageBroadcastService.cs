using ClockHackaInsight.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClockHackaInsight.Backend.Services
{
    public interface IMessageBroadcastService
    {
        void SendMessage(string userName, string userPhoneNumber, string messageContent);

        void SendMessage(User user, string messageContent);
    }
}
