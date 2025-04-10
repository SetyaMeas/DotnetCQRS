using System.Reflection;
using CQRS;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static void AddCQRSServices(this IHostApplicationBuilder builder, Assembly assembly)
    {
        builder.Services.AddScoped<ICommandDispatcher, CommandDispatcher>();
        builder.Services.AddScoped<IQueryDispatcher, QueryDispatcher>();
        builder.Services.AddScoped<IEventDispatcher, EventDispatcher>();

        builder.Services.Scan(selector =>
        {
            selector
                .FromAssemblies(assembly) // use assembly from the project that has the handler classes located
                .AddClasses(filter => filter.AssignableTo(typeof(ICommandHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime();
        });

        builder.Services.Scan(selector =>
        {
            selector
                .FromAssemblies(assembly)
                .AddClasses(filter => filter.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime();
        });

        builder.Services.Scan(selector =>
        {
            selector
                .FromAssemblies(assembly)
                .AddClasses(filter => filter.AssignableTo(typeof(IEventHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime();
        });
    }
}
