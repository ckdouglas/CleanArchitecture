using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentResults;


namespace CleanArchitecture.Application.Common.Errors;

public class DublicateEmailException : IError
{
    public List<IError> Reasons => new List<IError>
    {
        
    };

    public string Message => "Email already exists";

    public Dictionary<string, object> Metadata => new Dictionary<string, object>
    {
        {"ErrorCode", "DUPLICATE_EMAIL"}
    };
}