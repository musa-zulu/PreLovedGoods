using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PreLovedGoods.Application.Common.Interfaces;
using PreLovedGoods.Infrastructure.Services;
using PreLovedGoods.Infrastructure.Services.BackgroundServices.Reminders;
using PreLovedGoods.Infrastructure.Utils;
using System.Net;
using System.Net.Mail;

namespace PreLovedGoods.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddHttpContextAccessor()
            .AddServices()
            .AddBackgroundServices(configuration)
            .AddAuthentication(configuration)
            .AddAuthorization()
            .AddPersistence();

        return services;
    }

    private static IServiceCollection AddBackgroundServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEmailNotifications(configuration);

        return services;
    }

    private static IServiceCollection AddEmailNotifications(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        EmailSettings emailSettings = new();
        configuration.Bind(EmailSettings.Section, emailSettings);

        if (!emailSettings.EnableEmailNotifications)
        {
            return services;
        }

        services.AddHostedService<ReminderEmailBackgroundService>();

        services
            .AddFluentEmail(emailSettings.DefaultFromEmail)
            .AddSmtpSender(new SmtpClient(emailSettings.SmtpSettings.Server)
            {
                Port = emailSettings.SmtpSettings.Port,
                Credentials = new NetworkCredential(
                    emailSettings.SmtpSettings.Username,
                    emailSettings.SmtpSettings.Password),
            });

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>();

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        return services;
    }

    private static IServiceCollection AddAuthorization(this IServiceCollection services)
    {
        return services;
    }

    private static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}