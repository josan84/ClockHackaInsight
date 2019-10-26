using System;
using System.Collections.Generic;
using System.Text;

namespace ClockHackaInsight.Backend.Models
{
    public class UserFrequency
    {
        public DateTime LastMessaged { get; set; }
        public MessageFrequency Frequency { get; set; }
    }
}
