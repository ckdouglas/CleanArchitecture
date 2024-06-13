using CleanArchitecture.Api.Errors;
using CleanArchitecture.Application;
using CleanArchitecture.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication()
                    .AddInfrastructure(builder.Configuration);

    builder.Services.AddControllers();
    builder.Services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/errors");
    app.UseHttpsRedirection();
    app.MapControllers();
}

app.Run();


