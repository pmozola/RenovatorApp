using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RenovatorApp.Auth;

public static class ServiceExtensions
{
    public static IServiceCollection AddRenovatorAuthorization(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentityApiEndpoints<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedEmail = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(2);
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AuthDBContext>();

        services.AddDbContext<AuthDBContext>(options =>
            options.UseInMemoryDatabase("auth"));
        
       return services;
    }

    public static void UseRenovatorAuth(this WebApplication app)
    {
        app.UseAuthorization();
        app.MapGroup("/auth")
            .MapIdentityApi<IdentityUser>();
    }
}