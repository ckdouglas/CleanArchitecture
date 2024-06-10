using CleanArchitecture.Application.Common.Interfaces.Persistence;
using CleanArchitecture.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application;

public static class DependncyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            return services;
    }
}