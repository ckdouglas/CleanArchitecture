using FluentResults;

namespace CleanArchitecture.Application.Errors;

public class InvalidCredentialsError : IError
{
    public List<IError> Reasons => new List<IError>()
    {

    };

    public string Message => "Invalid credentials";

    public Dictionary<string, object> Metadata => new Dictionary<string, object>
    {
        {"ErrorCode", "invalid_credentials"}
    };
}