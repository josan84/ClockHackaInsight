using ClockHackaInsight.Backend.Models;
using System.Threading.Tasks;

namespace ClockHackaInsight.Backend.Services
{
    public interface IMotivationalQuotesService
    {
        Task<MotivationalQuote> GetRandomQuote();
        Task<MotivationalQuote> GetQuote(string id);
    }
}