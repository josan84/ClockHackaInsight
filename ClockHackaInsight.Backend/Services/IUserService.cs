using ClockHackaInsight.Backend.Models;
using System.Threading.Tasks;

namespace ClockHackaInsight.Backend.Services
{
    public interface IUserService
    {
        Task<User> SaveUser(User newUser);

        Task<User> UpdateUser(int id, User newUser);
    }
}