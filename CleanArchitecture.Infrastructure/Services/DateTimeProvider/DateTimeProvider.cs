using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CleanArchitecture.Application.Common.Interfaces.DateTimeProvider;

namespace CleanArchitecture.Infrastructure.Services.DateTimeProvider;
public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}