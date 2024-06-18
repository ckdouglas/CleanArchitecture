using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Services;
using ErrorOr;

namespace CleanArchitecture.Application.Services.Authentication.Commands;

public interface IAuthenticationCommmandService
{
    ErrorOr<AuthenticationResults> Register(string FirstName, string LastName, string Email, string Password);

}