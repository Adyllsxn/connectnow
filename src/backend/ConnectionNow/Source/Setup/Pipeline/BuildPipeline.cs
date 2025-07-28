namespace ConnectionNow.Source.Setup.Pipeline;
public static class BuildPipeline
{
    public static void AddBuildPipelines(this WebApplicationBuilder builder)
    {
        builder.AddControllersExtensions();
        builder.AddSwaggerExtensions();
        builder.AddLayersExtensions();
    }
}
