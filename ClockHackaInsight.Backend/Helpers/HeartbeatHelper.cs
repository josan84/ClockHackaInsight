using System.Threading.Tasks;
using ClockHackaInsight.Backend.Models;

namespace ClockHackaInsight.Backend.Helpers
{
    public class HeartbeatHelper : IHeartbeatHelper
    {
        public async Task<bool> ExecuteHeartbeatProtocol(HeartbeatData heartbeat)
        {
            return true;
        }
    }
}
