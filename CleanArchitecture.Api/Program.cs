using CleanArchitecture.Api.Errors;
using CleanArchitecture.Api.Filters;
using CleanArchitecture.Api.Middleware;
using CleanArchitecture.Application;
using CleanArchitecture.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder =  WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication()
                    .AddInfrastructure(builder.Configuration);
                    
    builder.Services.AddControllers
    (
         //Error handling with filters
        //options => options.Filters.Add<ErrorHandlingFilterAttribute>()
    );

    builder.Services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
}

var app =  builder.Build();
{
    //Error handling with Middleware.
    //app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/errors");
    app.UseHttpsRedirection();
    app.MapControllers();
}

app.Run();
