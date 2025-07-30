namespace ConnectionNow.Source.Setup.Extensions;
public static class JwtSetting
{
    public static void AddJwtExtensions(this WebApplicationBuilder builder)
    {
        var jwtKey = builder.Configuration["Jwt:Key"]!;

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtKey)),

                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true
            };

            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    context.Token = context.Request.Cookies["jwt"];
                    return Task.CompletedTask;
                }
            };
        });
    }
}
