namespace ConnectionNow.Source.Core.Application.Configuration;
public static class DependencyInjection
{
    public static void AddApplicationLayer (this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAuthService, AuthService>();
    }
}