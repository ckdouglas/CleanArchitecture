using ErrorOr;

namespace CleanArchitecture.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class User
        {
            public static Error DuplicateEmail => Error.Conflict(
                code: "User.DuplicateEmail",
                description: "Email already exists");

            public static Error InvalidCredentials => Error.Validation(
                code: "User.InvalidCredentials",
                description: "Invalid credentials");

            public static Error Unauthorized => Error.Unauthorized(
                code: "Common.Unauthorized",
                description: "Unauthorized");

            public static Error Forbidden => Error.Forbidden();

           
        }
    }
}