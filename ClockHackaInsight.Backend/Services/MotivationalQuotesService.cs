using ClockHackaInsight.Backend.Models;
using ClockHackaInsight.Backend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClockHackaInsight.Backend.Services
{
    public class MotivationalQuotesService : IMotivationalQuotesService
    {
        private readonly IDocumentDBRepository<MotivationalQuote> motivationalQuoteRepository;

        public MotivationalQuotesService(IDocumentDBRepository<MotivationalQuote> motivationalQuoteRepository)
        {
            this.motivationalQuoteRepository = motivationalQuoteRepository;
        }

        public async Task<MotivationalQuote> GetRandomQuote()
        {
            var quotes = await motivationalQuoteRepository.GetAllItems();

            var random = new Random();

            return quotes.ToArray()[random.Next(0, quotes.Count() - 1)];
        }

        public async Task<MotivationalQuote> GetQuote(string id)
        {
            return await motivationalQuoteRepository.GetItemAsync(id);
        }
    }
}
