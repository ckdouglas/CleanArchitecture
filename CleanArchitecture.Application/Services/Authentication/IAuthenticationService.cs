using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;

namespace CleanArchitecture.Application.Services.Authentication;
public interface IAuthenticationService
{
    Result<AuthenticationResults> Register(string FirstName, string LastName, string Email, string Password);
    Result<AuthenticationResults> Login(string Email, string Password);

}