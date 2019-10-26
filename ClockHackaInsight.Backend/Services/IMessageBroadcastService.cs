using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClockHackaInsight.Backend.Services
{
    public interface IMessageBroadcastService
    {
        void SendMessage();
        void SendMessage(string userName, string userPhoneNumber, string messageContent);

    }
}
