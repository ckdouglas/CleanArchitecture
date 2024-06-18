using CleanArchitecture.Application.Common.Interfaces.Persistence;
using CleanArchitecture.Application.Services.Authentication.Commands;
using CleanArchitecture.Application.Services.Authentication.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application;

public static class DependncyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationCommmandService, AuthenticationCommmandService>();
        services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
        return services;
    }
}