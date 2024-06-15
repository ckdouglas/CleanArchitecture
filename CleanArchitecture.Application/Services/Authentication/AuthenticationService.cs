using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Errors;
using CleanArchitecture.Application.Common.Interfaces.Authentication;
using CleanArchitecture.Application.Common.Interfaces.Persistence;
using CleanArchitecture.Application.Errors;
using CleanArchitecture.Domain.Entities;
using FluentResults;

namespace CleanArchitecture.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public Result<AuthenticationResults> Login(string email, string password)
    {
        //1. validate user exists
        if (_userRepository.GetUserByEmail(email) is not User user)
            return Result.Fail<AuthenticationResults>(new[] { new InvalidCredentialsError() }); //can pass one or more errors

        //2. validate password is correct
        if (user.Password != password)
            return Result.Fail<AuthenticationResults>(new[] { new InvalidCredentialsError() }); //can pass one or more errors

        //3. Create Jwt token

        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResults(
            user,
            token
        );
    }

    public Result<AuthenticationResults> Register(string firstName, string lastName, string email, string password)
    {
        // 1.valodate user does not exist
        var users = _userRepository.GetUserByEmail(email);
        if (users is not null)
            return Result.Fail<AuthenticationResults>(new[] { new DublicateEmailException() }); //can pass one or more errors

        // 2.Create a new user

        var user = _userRepository.Add(new User { FirstName = firstName, LastName = lastName, Email = email, Password = password });

        //3. Create JWT token

        if (user is not null)
        {
            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResults(
                user,
                token
            );
        }
        return Result.Fail<AuthenticationResults>(new[] {new UnExpectedError()}); //can pass one or more errors

    }

}
