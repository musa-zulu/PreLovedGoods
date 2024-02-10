using Microsoft.Extensions.Hosting;

namespace PreLovedGoods.Infrastructure.Services.BackgroundServices.Reminders;
public class ReminderEmailBackgroundService : IHostedService, IDisposable
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
