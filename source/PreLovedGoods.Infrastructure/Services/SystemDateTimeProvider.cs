using PreLovedGoods.Application.Common.Interfaces;

namespace PreLovedGoods.Infrastructure.Services;
public class SystemDateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
