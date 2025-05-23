using Grpc.Net.Client;
using TaskTrain.Contracts;

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

        app.MapGet("/hello", async () => {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new UserHub.UserHubClient(channel);
            var replyTask = client.CreateAsync(new CreateUserRequest() 
            {
                Login = "login",
                Password = "password",
                RepeatPassword = "password"
            });
            var result = await replyTask;
            var status = replyTask.GetStatus();
            return Results.Ok("hello");
        });

        app.Run();
    }
}
