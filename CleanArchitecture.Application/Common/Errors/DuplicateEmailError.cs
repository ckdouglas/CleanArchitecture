using System.Net;

namespace CleanArchitecture.Application.Errors;

public record  DuplicateEmailError : IError
{

    public int StatusCode => (int)HttpStatusCode.Conflict;
    public string ErrorMessage => "Email already in use";
};