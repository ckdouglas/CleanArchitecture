using FluentResults;

namespace CleanArchitecture.Application.Common.Errors;

public class UnExpectedError : IError
{
    public List<IError> Reasons { get; set; } = new List<IError>();

    public string Message => "Invalid credentials";

    public Dictionary<string, object> Metadata => new Dictionary<string, object>
    {
        {"ErrorCode", "invalid_credentials"}
    };

}