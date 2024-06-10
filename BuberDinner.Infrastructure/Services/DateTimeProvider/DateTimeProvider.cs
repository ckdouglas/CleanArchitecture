using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BuberDinner.Application.Common.Interfaces.DateTimeProvider;

namespace BuberDinner.Infrastructure.Services.DateTimeProvider;
public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}