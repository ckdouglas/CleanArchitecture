using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Services.Authentication;
using CleanArchitecture.Contracts.Authentication;
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
        var authResults =  _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

        var response =  new AuthenticationResponse(authResults.User.Id, authResults.User.FirstName, authResults.User.LastName, authResults.User.Email, authResults.Token);
        return Ok(response);
    }

    [HttpPost("login")]
    public ActionResult Login(LoginRequest request)
    {
        var authResults =  _authenticationService.Login(request.Email, request.Password);
        var response =  new AuthenticationResponse(authResults.User.Id, authResults.User.FirstName, authResults.User.LastName, authResults.User.Email, authResults.Token);
        return Ok(response);
    }
}