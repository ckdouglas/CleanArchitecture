
using CleanArchitecture.Api.Common.Errors;
using CleanArchitecture.Application;
using CleanArchitecture.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication()
                    .AddInfrastructure(builder.Configuration);

    builder.Services.AddControllers
    (
    );
    builder.Services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
}

app.Run();