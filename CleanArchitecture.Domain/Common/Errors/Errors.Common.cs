using ErrorOr;

namespace CleanArchitecture.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Common
        {
            public static Error UnExpectedError => Error.Unexpected();

            public static Error NotFound(string domain) => Error.NotFound(
                code: "404",
                description: $"{domain} not found"
            );
        }
    }
}