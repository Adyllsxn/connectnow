namespace ConnectionNow.Source.Setup.Extensions;
public static class ControllersExtensions
{
    public static void AddControllersExtensions(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
    }
}