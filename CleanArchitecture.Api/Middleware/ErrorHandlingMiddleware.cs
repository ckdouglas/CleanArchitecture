using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace CleanArchitecture.Api.Middleware;
public class ErrorHandlingMiddleware 
{
    private readonly RequestDelegate _next;
    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async  Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch(Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }
    
    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;
        var results =  JsonSerializer.Serialize(new {error = exception.Message});
        context.Response.ContentType = "application/json";
        context.Response.StatusCode =  (int)code;
        return context.Response.WriteAsync(results);
    }
}