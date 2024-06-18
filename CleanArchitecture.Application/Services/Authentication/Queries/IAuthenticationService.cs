using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;


namespace CleanArchitecture.Application.Services.Authentication;
public interface IAuthenticationQueryService
{
    ErrorOr<AuthenticationResults> Register(string FirstName, string LastName, string Email, string Password);
    ErrorOr<AuthenticationResults> Login(string Email, string Password);

}