using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RenovatorApp.Application.Handlers.Commands.Rooms.Add;
using RenovatorApp.Database;

namespace RenovatorApp.Application.IoC;

public static class RenovatorAppServicesExtensions
{
    public static IServiceCollection AddRenovatorAppServices(this IServiceCollection services)
    {
        services
            .AddDbContext<RenovatorDbContext>(options => options.UseInMemoryDatabase("RenovatorApp"));

        services
            .AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<AddRoomCommand>());

        return services;
    }
}