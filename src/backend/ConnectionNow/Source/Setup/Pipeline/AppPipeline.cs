namespace ConnectionNow.Source.Setup.Pipeline;
public static class AppPipeline
{
    public static void UseAppPipelines(this WebApplication app)
    {
        app.UseHttpsRedirection();
        app.UseSweggerExtensions();
        app.UseAuthorization();
        app.UseAuthorization();
        app.MapControllers();
    }
}
