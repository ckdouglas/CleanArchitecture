namespace CleanArchitecture.Application.Errors;

public interface IError
{
    public int StatusCode { get; }
    public string ErrorMessage { get; }
}