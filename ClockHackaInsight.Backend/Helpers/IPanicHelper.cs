using ClockHackaInsight.Backend.Models;
using System.Threading.Tasks;

namespace ClockHackaInsight.Backend.Helpers
{
    public interface IPanicHelper
    {
        public string GetPanicInfoMessage();

        public Task<string> GroundMe(User user);
    }
}
