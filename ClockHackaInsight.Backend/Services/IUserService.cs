using ClockHackaInsight.Backend.Models;
using System.Threading.Tasks;

namespace ClockHackaInsight.Backend.Services
{
    public interface IUserService
    {
        Task<User> GetUserById(string id);
        Task<User> GetUserByName(string name);
        Task<User> CreateUser(User newUser);
        Task<User> SaveUser(string id, User user);


    }
}