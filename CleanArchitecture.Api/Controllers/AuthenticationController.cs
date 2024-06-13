using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Errors;
using CleanArchitecture.Application.Services.Authentication;
using CleanArchitecture.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using OneOf;

namespace CleanArchitecture.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public ActionResult Register(RegisterRequest request)
    {
        OneOf<AuthenticationResults, IError> registrationResult = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

        return registrationResult.Match(
             result => Ok(MapAuthenticationResults(result)),
             error => Problem(statusCode: error.StatusCode, title: error.ErrorMessage)
        );
    }

    [HttpPost("login")]
    public ActionResult Login(LoginRequest loginRequest)
    {
        OneOf<AuthenticationResults, IError> loginResult = _authenticationService.Login(loginRequest.Email, loginRequest.Password);
        return loginResult.Match(
            authResults => Ok(MapAuthenticationResults(authResults)),
            error => Problem(statusCode: error.StatusCode, title: error.ErrorMessage)
        );
    }

    private static AuthenticationResponse MapAuthenticationResults(AuthenticationResults authResults)
    {
        return new AuthenticationResponse(authResults.User.Id, authResults.User.FirstName, authResults.User.LastName, authResults.User.Email, authResults.Token);
    }
}