namespace ConnectionNow.Source.Setup.Extensions;
public static class ExternalLayersExtensions
{
    public static void AddLayersExtensions(this WebApplicationBuilder builder)
    {
        builder.AddInfrastrutureLayer();
        builder.AddApplicationLayer();
    }
}