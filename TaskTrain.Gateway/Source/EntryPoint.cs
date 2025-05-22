namespace TaskTrain.Gateway;

internal static class EntryPoint
{
    public static void Main(string[] args) 
    {
        var builder = WebApplication.CreateSlimBuilder();

        builder.Configuration.Sources.Clear();
        builder.Configuration.LoadEnvironmentVariables();
        builder.Configuration.LoadAppsettingsJson();

        builder.Services.ConfigureJsonSerializer();

        var app = builder.Build();

        app.MapGet("/hello", () => { return Results.Ok("hello"); });

        app.Run();
    }
}
