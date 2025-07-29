namespace ConnectionNow.Source.Core.Infrastructure.Configuration;
public static class DependencyInjection
{
    public static void AddInfrastrutureLayer (this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("ConnectNowDb"));
    }
}
