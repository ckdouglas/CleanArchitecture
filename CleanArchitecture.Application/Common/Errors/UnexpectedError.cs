using System.Net;

namespace CleanArchitecture.Application.Errors;

public record UnexpectedError(string Message = "Unexpected error occured.") : IError
{
    public int StatusCode => (int)HttpStatusCode.InternalServerError;
    public string ErrorMessage => Message;
}