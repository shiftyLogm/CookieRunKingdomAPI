namespace CookieRunKingdomAPI.Services;

public static class BuildServices
{
    public static WebApplication UseBuildServices(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

        return app;
    }
}
