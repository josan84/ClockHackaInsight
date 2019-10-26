using ClockHackaInsight.Backend.Models;
using System.Threading.Tasks;

namespace ClockHackaInsight.Backend.Services
{
    public interface IUserService
    {
        Task<User> GetUserById(string id);
        Task<User> GetUserByName(string name);
        Task<User> SaveUser(User newUser);

        Task<User> UpdateUser(string id, User newUser);
    }
}