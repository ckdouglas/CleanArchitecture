using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Interfaces.DateTimeProvider;
public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}