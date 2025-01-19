using Calisthenics.Api.Users.Services;

namespace Calisthenics.Api.Users.Extensions;

public static class UsersInstallationExtensions
{
    public static void AddUserFeature(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        
    }
    
}