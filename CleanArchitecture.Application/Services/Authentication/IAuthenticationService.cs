using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Errors;
using OneOf;

namespace CleanArchitecture.Application.Services.Authentication;
public interface IAuthenticationService
{
    OneOf<AuthenticationResults, IError> Register(string FirstName, string LastName, string Email, string Password);
    OneOf<AuthenticationResults, IError> Login(string Email, string Password);

}