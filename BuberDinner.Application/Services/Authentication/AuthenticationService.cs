using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication;
public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public AuthenticationResults Login(string email, string password)
    {
        //1. validate user exists
        if(_userRepository.GetUserByEmail(email) is not User user)
            throw new Exception("User " + email + " does not exist");
        //2. validate password is correct
        if(user.Password != password)
            throw new Exception("Incorrect password!");
        //3. Create Jwt token

         var token =  _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResults(
                user,
                token
            );
    }

    public AuthenticationResults Register(string firstName, string lastName, string email, string password)
    {
         // 1.valodate user does not exist
          var users =  _userRepository.GetUserByEmail(email);
          if(users is not null)
            throw new Exception("User already exists");

         // 2.Create a new user

         var user = _userRepository.Add(new User{FirstName = firstName, LastName = lastName, Email = email, Password = password});
         
         //3. Create JWT token

         if(user is not null)
         {
            var token =  _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResults(
                user,
                token
            );
         }
         throw new Exception("Error creating user");

    }

}
