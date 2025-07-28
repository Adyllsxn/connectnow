namespace ConnectionNow.Source.Setup.Extensions;
public static class SwaggerExtensions
{
    public static void AddSwaggerExtensions(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(
            c =>
                c.SwaggerDoc("v1", new OpenApiInfo{
                    Title = "ConnoctNow MJ.API",
                    Version = "v1",
                    Description = "ConnectNow is a real-time chat app built with ASP.NET Core (SignalR, Middleware, CORS, Swagger, InMemory) and ReactJS. A didactic project to practice real-time communication and web architecture"
                })
        );
    }

    public static void UseSweggerExtensions(this WebApplication app)
    {
        if(app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
                c.ConfigObject.AdditionalItems["locale"] = "en";
            });
        }
    }
}
