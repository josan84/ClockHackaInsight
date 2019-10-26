using ClockHackaInsight.Backend.Models;
using ClockHackaInsight.Backend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClockHackaInsight.Backend.Services
{
    public class UserService : IUserService
    {
        private readonly IDocumentDBRepository<User> userRepository;

        public UserService(IDocumentDBRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<User> GetUser(string id)
        {
            return await userRepository.GetItemAsync(id);
        }

        public async Task<User> SaveUser(User newUser)
        {
            var document = await userRepository.CreateItemAsync(newUser);
            newUser.Id = document.Id;
            return newUser;
        }
    }
}
