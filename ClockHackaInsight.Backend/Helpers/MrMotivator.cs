using System;
using ClockHackaInsight.Backend.Models;

namespace ClockHackaInsight.Backend.Helpers
{
    public class MrMotivator : IMrMotivator
    {
        public MotivationalQuote MotivateMeOnce()
        {
            return new MotivationalQuote
            {
                Quote = "We fall so we can get back up again"
            };
        }
    }
}
