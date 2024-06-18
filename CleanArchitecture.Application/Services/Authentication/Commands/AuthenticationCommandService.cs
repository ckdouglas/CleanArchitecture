using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Errors;
using CleanArchitecture.Application.Common.Interfaces.Authentication;
using CleanArchitecture.Application.Common.Interfaces.Persistence;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Common.Errors;


using ErrorOr;

namespace CleanArchitecture.Application.Services.Authentication.Commands;
public class AuthenticationCommmandService : IAuthenticationCommmandService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationCommmandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResults> Register(string firstName, string lastName, string email, string password)
    {
        // 1.valodate user does not exist
        var users = _userRepository.GetUserByEmail(email);
        if (users is not null)
            return Errors.User.DuplicateEmail;

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
        return Errors.Common.UnExpectedError;
    }

}
