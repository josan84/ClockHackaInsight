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

        public async Task<User> GetUserById(string id)
        {
            return await userRepository.GetItemAsync(id);
        }

        public async Task<User> GetUserByName(string name)
        {
            var results = await userRepository.GetItemsAsync(u => u.Name == name);

            return results.FirstOrDefault();
        }

        public async Task<User> CreateUser(User newUser)
        {
            newUser.Frequency = new UserFrequency()
            {
                Frequency = Enums.MessageFrequency.Day
            };

            var document = await userRepository.CreateItemAsync(newUser);
            newUser.Id = document.Id;
            return newUser;
        }

        public async Task<User> SaveUser(string id, User user)
        {
            var userToUpdate = await userRepository.GetItemAsync(id);

            userToUpdate.Name = user.Name;
            userToUpdate.Number = user.Number;
            userToUpdate.Frequency = user.Frequency;

            await userRepository.UpdateItemAsync(id, userToUpdate);
            return user;
        }

        public async Task<User> UpdateUser(string id, User newUser)
        {
            await userRepository.UpdateItemAsync(id, newUser);

            return newUser;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await userRepository.GetAllItems();
        }
    }
}
