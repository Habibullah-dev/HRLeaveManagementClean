using HR.LeaveManagement.Infrastructure.EmailService.EmailSender;
using HR.LeaveManagement.Infrastructure.LoggingService;
using HR.LeaveManangement.Application.contracts.Email;
using HR.LeaveManangement.Application.contracts.Logging;
using HR.LeaveManangement.Application.Models.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.LeaveManagement.Infrastructure;

public static class InfrastructureServicesRegistration 
{
    public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

        services.AddTransient<IEmailSender, EmailSender>();

        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

        return services;
    }
}