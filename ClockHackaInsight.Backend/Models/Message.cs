using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClockHackaInsight.Backend.Models
{
    public class Message
    {
        public User Sender { get; set; }

        public User Receiver { get; set; }

        public string MessageContent { get; set; }

        public DateTime MessageDateTime { get; set; }


    }
}
