using ClockHackaInsight.Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClockHackaInsight.Backend.Services
{
    public interface IUserService
    {
        Task<User> GetUserById(string id);
        Task<User> GetUserByName(string name);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserByNumber(string number);
        Task<User> CreateUser(User newUser);
        Task<User> SaveUser(string id, User user);
    }
}