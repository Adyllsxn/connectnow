namespace ConnectionNow.Source.Setup.Pipeline;
public static class BuildPipeline
{
    public static void AddBuildPipelines(this WebApplicationBuilder builder)
    {
        builder.AddControllersExtensions();
        builder.AddJwtExtensions();
        builder.AddSwaggerExtensions();
        builder.AddLayersExtensions();
    }
}
