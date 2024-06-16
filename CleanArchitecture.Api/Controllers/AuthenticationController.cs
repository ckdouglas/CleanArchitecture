using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Services.Authentication;
using CleanArchitecture.Contracts.Authentication;
using CleanArchitecture.Domain.Common.Errors;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers;


[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        ErrorOr<AuthenticationResults> authResults = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);



        return authResults.Match(
            authResults => Ok(authResults),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResults = _authenticationService.Login(request.Email, request.Password);

        if (authResults.IsError && authResults.FirstError == Errors.User.InvalidCredentials)
        {
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResults.FirstError.Description);
        }

        return authResults.Match(
           authResults => Ok(authResults),
           errors => Problem(errors)

       );

    }
}