using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;


namespace CleanArchitecture.Application.Services.Authentication.Queries;
public interface IAuthenticationQueryService
{
    ErrorOr<AuthenticationResults> Login(string Email, string Password);

}