using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;


using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.DateTimeProvider;
using BuberDinner.Infrastructure.Services.DateTimeProvider;
using BuberDinner.Infrastructure.Services.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Infrastructure.Services.Persistence;


namespace BuberDinner.Infrastructure;

public static class DependancyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        
        services.Configure<JwtSettingsOptions>(configuration.GetSection(JwtSettingsOptions.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}