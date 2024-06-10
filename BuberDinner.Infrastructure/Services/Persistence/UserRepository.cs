using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infrastructure.Services.Persistence
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users =  new();
        public User? Add(User user)
        {
            _users.Add(user);
            return user;
        }

        public User? GetUserByEmail(string email)
        {
            return _users.FirstOrDefault(u => u.Email == email);
        }
    }
}