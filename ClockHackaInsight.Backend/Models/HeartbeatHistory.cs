using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClockHackaInsight.Backend.Models
{
    public class HeartbeatHistory
    {
        public DateTime DateTime { get; set; }
        public int AverageBpm { get; set; }
    }
}
