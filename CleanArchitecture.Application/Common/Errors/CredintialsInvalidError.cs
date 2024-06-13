using System.Net;

namespace CleanArchitecture.Application.Errors;

public record CredintialsInvalidError : IError
{
    public int StatusCode => (int)HttpStatusCode.Conflict;
    public string ErrorMessage => "Invalid credintials";
}