using System;

public class DateTimeBroker : IDateTimeBroker
{
    public DateTimeOffset GetCurrentDateTime() => DateTimeOffset.UtcNow;
}
