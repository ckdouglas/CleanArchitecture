using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Services.Authentication;
using CleanArchitecture.Application.Services.Authentication.Commands;
using CleanArchitecture.Application.Services.Authentication.Queries;
using CleanArchitecture.Contracts.Authentication;
using CleanArchitecture.Domain.Common.Errors;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers;


[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationCommmandService _authenticationCommandService;
    private readonly IAuthenticationQueryService _authenticationQueryService;

    public AuthenticationController(IAuthenticationCommmandService authenticationCommandService, IAuthenticationQueryService authenticationQueryService)
    {
        _authenticationCommandService = authenticationCommandService;
        _authenticationQueryService = authenticationQueryService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        ErrorOr<AuthenticationResults> authResults = _authenticationCommandService.Register(request.FirstName, request.LastName, request.Email, request.Password);



        return authResults.Match(
            authResults => Ok(authResults),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResults = _authenticationQueryService.Login(request.Email, request.Password);

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