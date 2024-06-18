using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Services;

namespace CleanArchitecture.Application.Services.Authentication;

public interface IAuthenticationCommmandService
{
    AuthenticationResults Register(string FirstName, string LastName, string Email, string Password);
    AuthenticationResults Login(string Email, string Password);

}