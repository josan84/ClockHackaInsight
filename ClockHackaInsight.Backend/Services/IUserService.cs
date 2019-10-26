using ClockHackaInsight.Backend.Models;
using System.Threading.Tasks;

namespace ClockHackaInsight.Backend.Services
{
    public interface IUserService
    {
        Task<User> GetUser(string id);
        Task<User> SaveUser(User newUser);
       
    }
}