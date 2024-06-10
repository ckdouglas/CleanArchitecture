using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Interfaces.Persistence;
public interface IUserRepository
{
    User? Add(User user);
    User? GetUserByEmail(string email);
}