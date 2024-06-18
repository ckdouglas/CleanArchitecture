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
<<<<<<< HEAD
        var authResults = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

        var response = new AuthenticationResponse(authResults.User.Id, authResults.User.FirstName, authResults.User.LastName, authResults.User.Email, authResults.Token);
        return Ok(response);
=======
        ErrorOr<AuthenticationResults> authResults = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);



        return authResults.Match(
            authResults => Ok(authResults),
            errors => Problem(errors)
        );
>>>>>>> flow_control_via_ErrorOr
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResults = _authenticationService.Login(request.Email, request.Password);
<<<<<<< HEAD
        var response = new AuthenticationResponse(authResults.User.Id, authResults.User.FirstName, authResults.User.LastName, authResults.User.Email, authResults.Token);
        return Ok(response);
=======

        if (authResults.IsError && authResults.FirstError == Errors.User.InvalidCredentials)
        {
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResults.FirstError.Description);
        }

        return authResults.Match(
           authResults => Ok(authResults),
           errors => Problem(errors)

       );

>>>>>>> flow_control_via_ErrorOr
    }
}