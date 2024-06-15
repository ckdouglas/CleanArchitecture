using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Errors;
using CleanArchitecture.Application.Errors;
using CleanArchitecture.Application.Services.Authentication;
using CleanArchitecture.Contracts.Authentication;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

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
        var authResults = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);
        if (authResults.IsSuccess)
        {
            var response = GetResponse(authResults.Value);
            return Ok(response);
        }

        var error1 = authResults.Errors[0];

        if (error1 is DublicateEmailException)
        {
            return Conflict(error1);
        }
        return Problem();
    }

    [HttpPost("login")]
    public ActionResult Login(LoginRequest request)
    {
        var authResults = _authenticationService.Login(request.Email, request.Password);
        if (authResults.IsSuccess)
        {
            var response = GetResponse(authResults.Value);
            return Ok(response);
        }

        var error1 = authResults.Errors[0];

        if (error1 is InvalidCredentialsError)
        {
            return Conflict(error1);
        }
        return Problem();
    }

    private static AuthenticationResponse GetResponse(AuthenticationResults authResults)
    {
        return new AuthenticationResponse(authResults.User.Id, authResults.User.FirstName, authResults.User.LastName, authResults.User.Email, authResults.Token);
    }
}