using Application.EmailService;
using Application.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace Application;
public static class ServiceExtension
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<ServiceClass>());
        services.AddAutoMapper(typeof(MappingConfig));
        services.AddTransient<IEmailSender, EmailSender>();
        return services;
    }

}

public class ServiceClass
{

}