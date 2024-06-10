using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuberDinner.Application.Services.Authentication;
public interface IAuthenticationService
{
    AuthenticationResults Register(string FirstName, string LastName, string Email, string Password);
    AuthenticationResults Login(string Email, string Password);

}