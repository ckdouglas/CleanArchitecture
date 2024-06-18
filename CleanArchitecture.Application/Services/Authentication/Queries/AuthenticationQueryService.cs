using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Errors;
using CleanArchitecture.Application.Common.Interfaces.Authentication;
using CleanArchitecture.Application.Common.Interfaces.Persistence;
using CleanArchitecture.Domain.Common.Errors;
using CleanArchitecture.Domain.Entities;
using ErrorOr;

namespace CleanArchitecture.Application.Services.Authentication.Queries;
public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResults> Login(string email, string password)
    {
        //1. validate user exists
        if (_userRepository.GetUserByEmail(email) is not User user)
            return new[] { Errors.User.InvalidCredentials, Errors.Common.NotFound("User") };
        //2. validate password is correct
        if (user.Password != password)
            return Errors.User.InvalidCredentials;
        //3. Create Jwt token

        //3. Create Jwt token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResults(
            user,
            token
        );
    }



}