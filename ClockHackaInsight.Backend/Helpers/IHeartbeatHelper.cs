using ClockHackaInsight.Backend.Models;
using System.Threading.Tasks;

namespace ClockHackaInsight.Backend.Helpers
{
    public interface IHeartbeatHelper
    {
        public Task<bool> ExecuteHeartbeatProtocol(HeartbeatData heartbeat);
    }
}
